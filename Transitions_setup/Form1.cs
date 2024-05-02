using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transitions_setup
{
    public partial class Form1 : Form
    {
        #region Export
        bool specialIDs;
        int export_file_copy_number;
        int export_file_replace_number;
        int export_file_passed_number;
        string export_TransitionPath = "";
        string export_ExportPath = "";
        string export_ObjectPath = "";
        #endregion
        #region Import
        int import_file_copy_number;
        int import_file_replace_number;
        int import_file_passed_number;
        string import_TransitionPath = "";
        //string import_ExportPath = "";
        string import_ObjectPath = "";
        string import_TransitionsToImportPath = "";
        #endregion

        List<string> export_IDs = new List<string>();
        public Form1()
        {
            InitializeComponent();
            specialIDs = false;
            labelIDs_export.Enabled = false;
            textBoxIDs_export.Enabled = false;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            export_file_copy_number = 0;
            export_file_replace_number = 0;
            export_file_passed_number = 0;
            export_IDs = new List<string>();
            //|| textBoxIDs_Export.Text == ""
            if (textBoxEditorGameFolderPath_export.Text == "" || textBoxOxzName_export.Text == "")
            {
                labelError_Export.ForeColor = Color.Red;
                labelError_Export.Text = "Empty Field";
                return;
            }
            if (!isFoldersPathGood(textBoxEditorGameFolderPath_export.Text, labelError_Export, true)) return;
            /*if (Directory.Exists(textBoxEditorGameFolderPath_export.Text))
            {
                if (Directory.Exists(textBoxEditorGameFolderPath_export.Text + "/transitions"))
                {
                    export_TransitionPath = textBoxEditorGameFolderPath_export.Text + "/transitions";
                }
                else { labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "transitions Folder dont exist"; return; }
                if (Directory.Exists(textBoxEditorGameFolderPath_export.Text + "/exports"))
                {
                    export_ExportPath = textBoxEditorGameFolderPath_export.Text + "/exports";
                }
                else { labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "export Folder dont exist"; return; }
                if (Directory.Exists(textBoxEditorGameFolderPath_export.Text + "/objects"))
                {
                    export_ObjectPath = textBoxEditorGameFolderPath_export.Text + "/objects";
                }
                else { labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "objects Folder dont exist"; return; }
            }
            else { labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Game Folder dont exist"; return; }
            */
            //string[] IDs_list = textBoxIDs_Export.Text.Split(',');

            //IDs
            if (!specialIDs)
            {
                string oxzFilePath = textBoxOxzName_export.Text;
                string[] oxzSeparateName = oxzFilePath.Split('_');
                int nbNewObject = 0;
                if (oxzSeparateName.Length > 1)
                {
                    if (!int.TryParse(oxzSeparateName[1], out nbNewObject))
                    {
                        labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Oxz file name problem"; return;
                    }
                }
                else { labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Oxz file name problem"; return; }

                string[] object_list_path = Directory.GetFiles(export_ObjectPath);
                int lastID = 0;
                if (object_list_path.Last() == "nextObjectNumber.txt")
                {
                    Console.WriteLine("object_list_path.Last() == nextObjectNumber.txt");
                    if (!int.TryParse(File.ReadAllLines(object_list_path.Last())[0], out lastID))
                    {
                        labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "cannot parse 'nextObjectNumber.txt' file"; return;
                    }
                }
                else
                {
                    bool nextObjNumfind = false;
                    // we shearch the nextObjectNumber.txt file
                    for (int i = object_list_path.Length - 1; i >= 0; i--)
                    {
                        if (Path.GetFileName(object_list_path[i]) == "nextObjectNumber.txt")
                        {
                            nextObjNumfind = true;
                            if (!int.TryParse(File.ReadAllLines(object_list_path[i])[0], out lastID))
                            {
                                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "cannot parse 'nextObjectNumber.txt' file"; return;
                            }
                        }
                    }
                    if (!nextObjNumfind)
                    {
                        labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "'nextObjectNumber.txt' file not find"; return;
                    }
                }

                int startID = lastID - nbNewObject; //should have -1 but +1 later
                List<int> IDs = new List<int>();
                int tmp = startID;
                for (int i = 0; i < nbNewObject; i++)
                {
                    tmp++;
                    IDs.Add(tmp);
                    export_IDs.Add(tmp + "");//Path.GetFileNameWithoutExtension(object_list_path[i]));
                }
                string allIDs = ""; IDs.ForEach(s => allIDs += s + ",");
                var confirmIDs = MessageBox.Show("The IDs are : " + allIDs + " is that corect ?", "Check the IDs", MessageBoxButtons.YesNo);
                if (confirmIDs != DialogResult.Yes)
                {
                    labelError_Export.ForeColor = Color.Red; labelError_Export.Text = " IDs not corect "; return;
                }
            }
            else
            {
                string[] IDs_list = textBoxIDs_export.Text.Split(',');
                export_IDs = IDs_list.ToList();
            }
                
            //string allIDs = ""; IDs.ForEach(s => allIDs += s + ",");
            //string allIDs = ""; export_IDs.ForEach(s => allIDs += s+",");
                
            string[] trans_list = Directory.GetFiles(export_TransitionPath);
            string exportPath = export_ExportPath + "/Transitions_" + textBoxOxzName_export.Text + "/";
            if (!Directory.Exists(exportPath))
                 Directory.CreateDirectory(exportPath);
            for (int i = 0; i < trans_list.Length; i++)
            {
                string fileName = Path.GetFileName(trans_list[i]);
                if (HasID(trans_list[i], export_IDs))
                {
                    string tmp_path = exportPath + fileName;
                    if (File.Exists(tmp_path))
                    {
                        var confirmResult = MessageBox.Show(fileName + " already exist, Replace ?", "File already exist", MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            export_file_replace_number++;
                            File.Copy(trans_list[i], exportPath + fileName, true);
                        }
                        else
                        {
                            export_file_passed_number++;
                        }
                    }
                    else
                    {
                        export_file_copy_number++;
                        File.Copy(trans_list[i], exportPath + fileName);
                    }
                }
                
                labelError_Export.ForeColor = Color.Green;
                labelError_Export.Text = export_file_copy_number + " files copy / " + export_file_replace_number + " files replace / " + export_file_passed_number + " files passed";
            }
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(exportPath + "Old_IDs_List.txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(CombineList(export_IDs));
                    fs.Write(info, 0, info.Length);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                labelError_Export.ForeColor = Color.Red;
                labelError_Export.Text = "Problem writing 'Old_IDs_List.txt' file";
            }
        }
        private bool isFoldersPathGood(string pathGameFolder, Label errorLabel, bool export)
        {
            if (Directory.Exists(pathGameFolder))
            {
                if (Directory.Exists(pathGameFolder + "/transitions"))
                {
                    if(export) export_TransitionPath = pathGameFolder + "/transitions";
                    else import_TransitionPath = pathGameFolder + "/transitions";
                }
                else { errorLabel.ForeColor = Color.Red; errorLabel.Text = "transitions Folder dont exist"; return false; }
                if (export)
                {
                    if (Directory.Exists(pathGameFolder + "/exports"))
                    {
                        if (export) export_ExportPath = pathGameFolder + "/exports";
                        //else import_ExportPath = pathGameFolder + "/exports";
                    }

                    else { errorLabel.ForeColor = Color.Red; errorLabel.Text = "export Folder dont exist"; return false; }
                }
                if (Directory.Exists(pathGameFolder + "/objects"))
                {
                    if (export) export_ObjectPath = pathGameFolder + "/objects";
                    else import_ObjectPath = pathGameFolder + "/objects";
                }
                else { errorLabel.ForeColor = Color.Red; errorLabel.Text = "objects Folder dont exist"; return false; }
            }
            else { errorLabel.ForeColor = Color.Red; errorLabel.Text = "Game Folder dont exist"; return false; }
            return true;
        }
        private string CombineList(List<string> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i]+",";
            }
            return result;
        }
        private bool HasID(string filePath, List<string> IDs)
        {
            string[] fileName = Path.GetFileNameWithoutExtension(filePath).Split('_');
            if(fileName.Length<2) return false;
            for (int i = 0; i < IDs.Count; i++)
            {
                if (fileName[0] == IDs[i] || fileName[1] == IDs[i])
                {
                    return true;
                }
                foreach (string s in File.ReadLines(filePath))
                {
                    Console.WriteLine(s);
                    string[] tmp = s.Split(' ');
                    string tmp1 = tmp[0];
                    string tmp2 = tmp[1];
                    if (IDs.Contains(tmp1) || IDs.Contains(tmp2))
                    {
                        return true;
                    }
                    break; // Only read first line
                };
            }
            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            specialIDs= !specialIDs;
            labelIDs_export.Enabled = !labelIDs_export.Enabled;
            textBoxIDs_export.Enabled = !textBoxIDs_export.Enabled;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBoxGameFolderPath.Text == "")
            {
                labelError_import.ForeColor = Color.Red;
                labelError_import.Text = "Empty Field";
                return;
            }
            import_file_copy_number = 0;
            import_file_replace_number = 0;
            import_file_passed_number = 0;
            if (!isFoldersPathGood(textBoxGameFolderPath.Text, labelError_import, false)) return;
            //!!
            //Maybe need test if there is only .txt file and setting file in the imported transition folder here
            //!!
            import_TransitionsToImportPath = import_TransitionPath + "/Transitions_" + textBoxOxzFileName_import.Text;
            if (!Directory.Exists(import_TransitionsToImportPath))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "Could not find 'Transitions_" + textBoxOxzFileName_import.Text+"' folder.";return;
            }
            string oldIDs_list_path = import_TransitionsToImportPath + "/Old_IDs_List.txt";
            if (!File.Exists(oldIDs_list_path))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "Could not find 'Old_IDs_List.txt' file"; return;
            }
            string[] oldIDs_list;
            string tmp="";
            foreach (string line in File.ReadLines(oldIDs_list_path))
            {
                tmp += line;
            }
            List<string> newIDs_list = new List<string>();
            oldIDs_list = tmp.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            string[] list_objects = Directory.GetFiles(import_ObjectPath);
            int nbObject = oldIDs_list.Length;
            Console.WriteLine("nbObject : "+nbObject);

            int lastID = 0;
            bool nextObjNumfind = false;
            // we shearch the nextObjectNumber.txt file
            for (int i = list_objects.Length - 1; i >= 0; i--)
            {
                if (Path.GetFileName(list_objects[i]) == "nextObjectNumber.txt")
                {
                    nextObjNumfind = true;
                    if (!int.TryParse(File.ReadAllLines(list_objects[i])[0], out lastID))
                    {
                        labelError_import.ForeColor = Color.Red; labelError_import.Text = "cannot parse 'nextObjectNumber.txt' file"; return;
                    }
                }
            }
            if (!nextObjNumfind)
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "'nextObjectNumber.txt' file not find"; return;
            }
            int startID = lastID - nbObject; //-1 but +1 so nothing
            int tmp_num=startID;
            for(int i=0; i<nbObject; i++)
            {
                Console.WriteLine(tmp_num+" added");
                newIDs_list.Add(tmp_num+"");
                tmp_num++;
            }

            string[] list_trans_import = Directory.GetFiles(import_TransitionsToImportPath);

            string[] listNewName = new string[list_trans_import.Length];
            string[] listNewPath = new string[list_trans_import.Length];

            // This loop is for modify data and name of the file and put it in a file with no extension to prevent erase a file with same name
            for (int i =0; i < list_trans_import.Length; i++) //Every files
            {
                if (Path.GetFileName(list_trans_import[i]) == "Old_IDs_List.txt") continue;

                #region FileData
                string[] fileData = File.ReadAllLines(list_trans_import[i]);
                string[] oldFileData = new string[fileData.Length]; //need remove maybe
                string[] newFileData = new string[fileData.Length];

                for (int x=0;x< fileData.Length;x++) // for all the lines

                {
                    //Console.WriteLine("line : " + fileData[x]);
                    string[] lineS = fileData[x].Split(' ');
                    //if that not the first line, we just copy
                    if (x > 0)
                    {
                        newFileData[x] = fileData[x];
                        continue;
                    }

                    for (int j = 0; j < lineS.Length; j++)//for all the character in the line
                    {
                        //Console.WriteLine("lineS : " + lineS[j]);
                        if (j > 1) // if that not the first or second, we just copy
                        {
                            newFileData[x] += lineS[j] + " "; continue;
                            
                        }
                        bool ID_match = false;
                        for (int k = 0; k < oldIDs_list.Length; k++) // for all the IDs
                        {
                            //Console.WriteLine("i = " + i + " j = " + j + " k = " + k);
                            //Console.WriteLine("oldIDs_list : " + oldIDs_list[k]);

                            if (lineS[j] == oldIDs_list[k])
                            {
                                ID_match = true;
                                newFileData[x] += newIDs_list[k] + " ";
                                break;
                            }
                        }
                        // If the first or seconde are not a ID matching, we just copy 
                        if (!ID_match) 
                        { 
                            newFileData[x] += lineS[j] + " ";
                        }
                    }

                }
                Console.WriteLine("New file data : " + newFileData[0]);
                File.WriteAllLines(list_trans_import[i],newFileData);
                #endregion


                #region Name file
                string oldName = Path.GetFileNameWithoutExtension(list_trans_import[i]);
                string newName ="";

                string[] fileName = oldName.Split('_');
                for(int a = 0;a < fileName.Length;a++)
                {
                    bool find = false;
                    for(int j=0;j< oldIDs_list.Length;j++)
                    {
                        if (fileName[a] == oldIDs_list[j])
                        {
                            newName += newIDs_list[j]+"_";
                            find = true;
                        }
                    }
                    if (!find)
                    {
                        newName += fileName[a] +"_";
                    }
                    
                }
                newName = newName.Remove(newName.Length - 1);
                listNewName[i] = newName;
                string oldNamePath = list_trans_import[i];
                string newNamePath = import_TransitionsToImportPath + "/" + newName;// +".txt";
                listNewPath[i] = newNamePath;
                Console.WriteLine("oldNamePath : "+ oldNamePath);
                Console.WriteLine("newNamePath : " + newNamePath);
                if (File.Exists(newNamePath))
                {
                    labelError_import.ForeColor = Color.Red;
                    labelError_import.Text = "Temporary file named : "+newName+" already exist in the imported transition folder."; return;
                }
                else
                {
                    //Maybe need remove old file here
                    File.Move(oldNamePath, newNamePath); // HERE PROBLEM FILE ALREADY EXIST, Need TMP folder ?
                }
                #endregion

                
            }
            // this loop is for copy the file with no extension into the main transition folder
            for (int i = 0; i < list_trans_import.Length; i++) //Every files
            {
                if (Path.GetFileName(list_trans_import[i]) == "Old_IDs_List.txt") continue;

                #region MoveToTransitionFolder
                string finalFilePath = import_TransitionPath + "/" + listNewName[i] + ".txt";
                if (!File.Exists(finalFilePath))
                {
                    File.Move(listNewPath[i], finalFilePath);
                    import_file_copy_number++;
                }
                else
                {
                    var confirmIDs = MessageBox.Show("Transition : " + listNewName[i] + ".txt already exist, Replace ?", "Transition replace ?", MessageBoxButtons.YesNo);
                    if (confirmIDs == DialogResult.Yes)
                    {
                        //Here need remove file befor maybe
                        //File.Delete(finalFilePath); // ok ???
                        File.Move(listNewPath[i], finalFilePath);
                        import_file_replace_number++;
                    }
                    else
                    {
                        import_file_passed_number++;
                    }
                }
                #endregion

                
            }
            if (checkBoxDeleteOldTransFolder.Checked == true)
            {
                Directory.Delete(import_TransitionsToImportPath,true);
            }
            File.Delete(import_TransitionPath+"/cache.fcz"); // to make sure that reload transitions
            labelError_import.ForeColor = Color.Green;
            labelError_import.Text = import_file_copy_number + " files copy / " + import_file_replace_number + " files replace / " + import_file_passed_number + " files passed";
        }

        private void checkBoxDeleteOldTransFolder_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEditorGameFolderPath_export_TextChanged(object sender, EventArgs e)
        {
            //textBoxEditorGameFolderPath_export.DataBindings.Add("Checked", Properties.Settings.Default, "TextBoxEditorFolder", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //textBoxEditorGameFolderPath_export.DataBindings.Add("Text", Properties.Settings.Default, "textBoxEditorGameFolderPath_export", true, DataSourceUpdateMode.OnPropertyChanged);
            
            //textBoxGameFolderPath.DataBindings.Add("Text", Properties.Settings.Default, "TextBox2", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
