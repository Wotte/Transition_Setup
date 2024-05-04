using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transitions_setup
{
    public partial class Form1 : Form
    {
        string trtFileExtension = ".trt";
        string oxzFileExtension = ".oxz";
        #region Export
        bool specialIDs;
        int export_file_copy_number;
        int export_file_replace_number;
        int export_file_passed_number;
        string export_TransitionPath = "";
        string export_ExportPath = "";
        string export_ObjectPath = "";
        List<string> export_IDs = new List<string>();
        #endregion
        #region Import
        bool deleteOldFile;
        int import_file_copy_number;
        int import_file_replace_number;
        int import_file_passed_number;
        string import_TransitionPath = "";
        //string import_ExportPath = "";
        string import_ObjectPath = "";
        string import_TransitionsToImportPath = "";
        string import_import_addPath = "";
        string import_import_replacePath = "";
        List<int> im_newIDs = new List<int>();
        List<int> im_oldIDs = new List<int>();
        #endregion

        
        public Form1()
        {
            InitializeComponent();
            specialIDs = false;
            deleteOldFile = checkBoxDeleteOldFiles.Checked;
            Console.WriteLine("FORM1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            export_file_copy_number = 0; export_file_replace_number = 0; export_file_passed_number = 0;
            export_IDs = new List<string>();
            string oxzFilePath = textBoxEditorGameFolderPath_export.Text;
            
            if (oxzFilePath == "")
            {
                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Empty Field"; return;
            }
            string oxzFileName = Path.GetFileNameWithoutExtension(oxzFilePath);
            string transitionExportFileName = oxzFileName + trtFileExtension;

            #region Check Folder Acess
            string gameFolderPath = Directory.GetParent(oxzFilePath).Parent.FullName;
            Console.WriteLine(gameFolderPath);

            export_TransitionPath = gameFolderPath + "/transitions/";
            Console.WriteLine(export_TransitionPath);

            export_ExportPath = gameFolderPath + "/exports/";
            Console.WriteLine(export_ExportPath);
            export_ObjectPath = gameFolderPath + "/objects/";
            Console.WriteLine(export_ObjectPath);

            if (!Directory.Exists(export_TransitionPath))
            {
                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Transitions folder do not exist"; return;
            }
            if (!Directory.Exists(export_ExportPath))
            {
                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Exports folder do not exist"; return;
            }
            if (!Directory.Exists(export_ObjectPath))
            {
                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Objects folder do not exist"; return;
            }
            #endregion

            #region Get number of objects exported
            string[] oxzSeparateName = oxzFileName.Split('_');
            int nbNewObject = 0;
            if (oxzSeparateName.Length > 1 && !int.TryParse(oxzSeparateName[1], out nbNewObject))
            {
                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "Oxz file name problem"; return;
            }
            #endregion

            #region Get the last ID
            string[] object_list_path = Directory.GetFiles(export_ObjectPath);
            int lastID = 0;
            //First we look if the file is the last in the folder
            if (object_list_path.Last() == "nextObjectNumber.txt")
            {
                if (!int.TryParse(File.ReadAllLines(object_list_path.Last())[0], out lastID))
                {
                    labelError_Export.ForeColor = Color.Red; labelError_Export.Text = "cannot parse 'nextObjectNumber.txt' file"; return;
                }
            }
            //if not we look all the folder to find it
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
            #endregion

            #region Create IDs
            int startID = lastID - nbNewObject-1; //should have -1 but +1 later
            List<int> IDs = new List<int>();
            int tmp = startID;
            for (int i = 0; i < nbNewObject; i++)
            {
                tmp++;
                IDs.Add(tmp);
                export_IDs.Add(tmp + "");
            }
            #endregion

            #region Show IDs
            string allIDs = "";
            for (int i =0;i< IDs.Count;i++)
            {
                allIDs += IDs[i];
                if (i != IDs.Count) allIDs += ",";
            }
            var confirmIDs = MessageBox.Show("The IDs are : " + allIDs + " is that corect ?", "Check the IDs", MessageBoxButtons.YesNo);
            if (confirmIDs != DialogResult.Yes)
            {
                labelError_Export.ForeColor = Color.Red; labelError_Export.Text = " IDs not corect "; return;
            }
            #endregion

            #region Select good transitions
            string[] trans_list = Directory.GetFiles(export_TransitionPath);
            List<string> trans_list_choosed = new List<string>();

            for (int i = 0; i < trans_list.Length; i++)
            {
                string fileName = Path.GetFileName(trans_list[i]);
                if (HasID(trans_list[i], export_IDs))
                {
                        export_file_copy_number++;
                        trans_list_choosed.Add(trans_list[i]);
                }
            }
            #endregion

            labelError_Export.ForeColor = Color.Green;
            labelError_Export.Text = export_file_copy_number + " files copy / " + export_file_replace_number + " files replace / " + export_file_passed_number + " files passed";


            CreateFile(trans_list_choosed, Path.Combine(export_ExportPath + transitionExportFileName),IDs);
            
        }

        private void CreateFile(List<string> fileList, string newFilePath,List<int> IDList)
        {
            List<string> dataList = new List<string>();
            //if(!File.Exists(newFilePath))File.Create(newFilePath);
            dataList.Add(GetIDsString(IDList));
            foreach (var file in fileList)
            {
                dataList.Add(Path.GetFileName(file));
                foreach (var line in File.ReadLines(file))
                {
                    dataList.Add(line);
                }
                //if(file != fileList.Last())
                    dataList.Add(";;"); // To separate every files (needed when reading)
            }
            File.WriteAllLines(newFilePath,dataList);
        }
        private List<string> OpenFile(string filePath, string transitionFolderPath)
        {
            im_oldIDs = new List<int>();
            List<string> fileList = new List<string>();
            bool firstOfTheFile = true;
            int count = 0; string tmpTransitionFilePath="";
            List<string> tmpLineList = new List<string>();

            Console.WriteLine("OPEN FILE ");

            foreach (var line in File.ReadLines(filePath))
            {
                if (firstOfTheFile)
                {
                    var tmp = line.Split(',');
                    #region Get Old IDs
                    for (int i=0;i< tmp.Length;i++)
                    {
                        int tmpInt;
                        if (!int.TryParse(tmp[i], out tmpInt))
                        {
                            //Need error message here
                            return null;
                        }
                        im_oldIDs.Add(tmpInt);
                    }
                    #endregion
                    firstOfTheFile = false;
                    continue;
                }
                if (count == 0) //Name of the file
                {
                    string lineTmp = line.Remove(line.Length-4); // remove '.txt'
                    string[] listTmp = lineTmp.Split('_');
                    string firstID = listTmp[0];
                    string secondID = listTmp[1];
                    string rest = "";
                    
                    bool first = false; bool second= false; // to prevent erase an already modify ID
                    for (int i =0;i< im_oldIDs.Count;i++)
                    {
                        if (!first && firstID == im_oldIDs[i].ToString())
                        {
                            firstID = im_newIDs[i].ToString(); first = true;
                        }
                        if (!second && secondID == im_oldIDs[i].ToString())
                        {
                            secondID = im_newIDs[i].ToString(); second = true;
                        }
                        if (first && second) break; // break the loop if we already find both
                    }
                    if (listTmp.Length > 2) //put the _LT etc..
                        rest = "_" + listTmp[2];
                    tmpTransitionFilePath = transitionFolderPath + firstID+"_"+secondID+ rest + ".txt";
                }
                else if (count == 1) // first line of the file (where there is Third and Fourth ID)
                {
                    
                    string[] listTmp = line.Split(' ');
                    string thirdID = listTmp[0];
                    string fourthID = listTmp[1];

                    bool third = false; bool fourth = false; // to prevent erase an already modify ID
                    for (int i = 0; i < im_oldIDs.Count; i++)
                    {
                        if (!third && thirdID == im_oldIDs[i].ToString())
                        {
                            thirdID = im_newIDs[i].ToString(); third = true;
                        }
                        if (!fourth && fourthID == im_oldIDs[i].ToString())
                        {
                            fourthID = im_newIDs[i].ToString(); fourth = true;
                        }
                        if (third && fourth) break; // break the loop if we already find both
                    }
                    string modifyLine = thirdID+" "+fourthID;
                    for (int a = 2; a < listTmp.Length; a++) // we start at 2 cause third and fourth modify
                    {
                        modifyLine += " "+listTmp[a];
                    }
                    
                    tmpLineList.Add(modifyLine);

                }
                else // other lines ( description + authors )
                {
                    if(line != ";;") tmpLineList.Add(line); //if needed to not add the ";;" line into the file
                }

                if(line == ";;") // at the end of a file we create the new file
                {

                    // !!!!!!!!!!!
                    // Maybe Ask to replace here
                    // !!!!!!!!!!!
                    
                    /*Console.WriteLine("Create file : ");
                    Console.WriteLine("Path : "+ tmpTransitionFilePath);
                    Console.WriteLine("tmpLineList Count : " + tmpLineList.Count);*/

                    File.WriteAllLines(tmpTransitionFilePath, tmpLineList);
                    fileList.Add(tmpTransitionFilePath);
                    count = 0;
                    tmpLineList.Clear();
                }
                else
                {
                    count++;
                }
                
            }
            return fileList;
        }

        private string GetIDsString(List<int> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                 result+= list[i].ToString();
                if (i != list.Count - 1) result += ",";
            }
            return result;
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            import_file_copy_number = 0; import_file_replace_number = 0; import_file_passed_number = 0;
            string trtFilePath = textBoxGameFolderPath.Text;

            if (trtFilePath == "")
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "Empty Field"; return;
            }
            string trtFileName = Path.GetFileNameWithoutExtension(trtFilePath);

            #region Check Folder Acess
            string gameFolderPath = Directory.GetParent(trtFilePath).Parent.FullName;
            import_TransitionPath = gameFolderPath + "/transitions/";
            import_ObjectPath = gameFolderPath + "/objects/";
            import_import_addPath = gameFolderPath + "/import_add/";
            import_import_replacePath = gameFolderPath + "/import_replace/";
            if (!Directory.Exists(import_TransitionPath))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "transitions Folder dont exist"; return;
            }
            if (!Directory.Exists(import_ObjectPath))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "objects Folder dont exist"; return;
            }
            if (!Directory.Exists(import_import_addPath))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "import_add Folder dont exist"; return;
            }
            if (!Directory.Exists(import_import_replacePath))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "import_replace Folder dont exist"; return;
            }
            #endregion

            #region Shearch the nextObjectNumber.txt file and return nextID
            string[] list_objects = Directory.GetFiles(import_ObjectPath);
            int nextID = 0; bool nextObjNumfind = false;

            for (int i = list_objects.Length - 1; i >= 0; i--)
            {
                if (Path.GetFileName(list_objects[i]) == "nextObjectNumber.txt")
                {
                    nextObjNumfind = true;
                    if (!int.TryParse(File.ReadAllLines(list_objects[i])[0], out nextID))
                    {
                        labelError_import.ForeColor = Color.Red; labelError_import.Text = "cannot parse 'nextObjectNumber.txt' file"; return;
                    }
                }
            }
            if (!nextObjNumfind)
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "'nextObjectNumber.txt' file not find"; return;
            }
            #endregion

            #region Set New IDs
            im_newIDs = new List<int>();
            string[] trtFileNameSeparated = trtFileName.Split('_');
            int nbObject = 0;
            if (!int.TryParse(trtFileNameSeparated[trtFileNameSeparated.Length-2], out nbObject))
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = "trt file name problem (parse)"; return;
            }

            Console.WriteLine("nbObject : " + nbObject);
            int startID = nextID - nbObject; // -1 but +1  
            int tmp_num = startID;
            for (int i = 0; i < nbObject; i++)
            {
                Console.WriteLine(tmp_num + " added");
                im_newIDs.Add(tmp_num);
                tmp_num++;
            }

            #endregion

            // we modify transition directly when we open file
            List<string> trtFilesPath = OpenFile(trtFilePath,import_TransitionPath);
            if(trtFilePath == null)
            {
                labelError_import.ForeColor = Color.Red; labelError_import.Text = ".trt File, first line problem"; return;
            }

            /*
            
            #region Modify transitions
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

            #endregion

            */

            #region Delete Old Files
            if (checkBoxDeleteOldFiles.Checked == true)
            {
                string tmp_path = import_import_addPath + trtFileName;
                if (File.Exists(tmp_path + trtFileExtension))
                    File.Delete(tmp_path + trtFileExtension);
                if (File.Exists(tmp_path + oxzFileExtension))
                    File.Delete(tmp_path + oxzFileExtension);
                tmp_path = import_import_replacePath + trtFileName;
                if (File.Exists(tmp_path + trtFileExtension))
                    File.Delete(tmp_path + trtFileExtension);
                if (File.Exists(tmp_path + oxzFileExtension))
                    File.Delete(tmp_path + oxzFileExtension);
            }
            #endregion

            File.Delete(import_TransitionPath+"cache.fcz"); // to make sure that reload transitions

            labelError_import.ForeColor = Color.Green;
            labelError_import.Text = import_file_copy_number + " files copy / " + import_file_replace_number + " files replace / " + import_file_passed_number + " files passed";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Console.WriteLine("FORM1 LOAD");
            //textBoxEditorGameFolderPath_export.DataBindings.Add("Text", Properties.Settings.Default, "textBoxEditorGameFolderPath_export", true, DataSourceUpdateMode.OnPropertyChanged);
            //textBoxGameFolderPath.DataBindings.Add("Text", Properties.Settings.Default, "TextBox2", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "oxz files (*.oxz)|*.oxz|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxEditorGameFolderPath_export.Text = openFileDialog.FileName;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "trt files (*.trt)|*.trt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxGameFolderPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void checkBoxDeleteOldFiles_CheckedChanged(object sender, EventArgs e)
        {
            //deleteOldFile = checkBoxDeleteOldFiles.Checked;
        }
    }
}
