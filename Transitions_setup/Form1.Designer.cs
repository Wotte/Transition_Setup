namespace Transitions_setup
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelError_Export = new System.Windows.Forms.Label();
            this.textBoxOxzName_export = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelIDs_export = new System.Windows.Forms.Label();
            this.textBoxIDs_export = new System.Windows.Forms.TextBox();
            this.textBoxEditorGameFolderPath_export = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxDeleteOldTransFolder = new System.Windows.Forms.CheckBox();
            this.textBoxOxzFileName_import = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelError_import = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGameFolderPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.labelError_Export);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxOxzName_export);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.labelIDs_export);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxIDs_export);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxEditorGameFolderPath_export);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxDeleteOldTransFolder);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxOxzFileName_import);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.labelError_import);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxGameFolderPath);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(313, 48);
            this.label14.TabIndex = 16;
            this.label14.Text = "- Make sure all objects are the last in the list objects\r\n- Make sure to only exp" +
    "ort the Objects you\'ve create\r\n- Export the oxz file through the \"EditOneLife.ex" +
    "e\"\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "BEFOR EXPORT :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Export button will put in a folder all the transition that \r\ncontain any referenc" +
    "e to the IDs object write by hand or find";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(15, 250);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Write IDs";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labelError_Export
            // 
            this.labelError_Export.AutoSize = true;
            this.labelError_Export.Location = new System.Drawing.Point(43, 365);
            this.labelError_Export.Name = "labelError_Export";
            this.labelError_Export.Size = new System.Drawing.Size(0, 16);
            this.labelError_Export.TabIndex = 9;
            // 
            // textBoxOxzName_export
            // 
            this.textBoxOxzName_export.Location = new System.Drawing.Point(12, 221);
            this.textBoxOxzName_export.Name = "textBoxOxzName_export";
            this.textBoxOxzName_export.Size = new System.Drawing.Size(362, 22);
            this.textBoxOxzName_export.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(115, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Check this button if all the objects \r\nexported are not ALL the last one on the l" +
    "ist\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Oxz file name (without extension) :";
            // 
            // labelIDs_export
            // 
            this.labelIDs_export.AutoSize = true;
            this.labelIDs_export.Location = new System.Drawing.Point(12, 283);
            this.labelIDs_export.Name = "labelIDs_export";
            this.labelIDs_export.Size = new System.Drawing.Size(164, 16);
            this.labelIDs_export.TabIndex = 4;
            this.labelIDs_export.Text = "IDs (separate by comma) :";
            // 
            // textBoxIDs_export
            // 
            this.textBoxIDs_export.Location = new System.Drawing.Point(12, 302);
            this.textBoxIDs_export.Name = "textBoxIDs_export";
            this.textBoxIDs_export.Size = new System.Drawing.Size(362, 22);
            this.textBoxIDs_export.TabIndex = 3;
            // 
            // textBoxEditorGameFolderPath_export
            // 
            this.textBoxEditorGameFolderPath_export.Location = new System.Drawing.Point(12, 177);
            this.textBoxEditorGameFolderPath_export.Name = "textBoxEditorGameFolderPath_export";
            this.textBoxEditorGameFolderPath_export.Size = new System.Drawing.Size(362, 22);
            this.textBoxEditorGameFolderPath_export.TabIndex = 2;
            this.textBoxEditorGameFolderPath_export.TextChanged += new System.EventHandler(this.textBoxEditorGameFolderPath_export_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Game EDITOR Folder Path :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "EXPORT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 386);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(398, 64);
            this.label12.TabIndex = 12;
            this.label12.Text = resources.GetString("label12.Text");
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(174, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "Options :";
            // 
            // checkBoxDeleteOldTransFolder
            // 
            this.checkBoxDeleteOldTransFolder.AutoSize = true;
            this.checkBoxDeleteOldTransFolder.Location = new System.Drawing.Point(112, 264);
            this.checkBoxDeleteOldTransFolder.Name = "checkBoxDeleteOldTransFolder";
            this.checkBoxDeleteOldTransFolder.Size = new System.Drawing.Size(194, 20);
            this.checkBoxDeleteOldTransFolder.TabIndex = 12;
            this.checkBoxDeleteOldTransFolder.Text = "Delete old transition folder ?";
            this.checkBoxDeleteOldTransFolder.UseVisualStyleBackColor = true;
            this.checkBoxDeleteOldTransFolder.CheckedChanged += new System.EventHandler(this.checkBoxDeleteOldTransFolder_CheckedChanged);
            // 
            // textBoxOxzFileName_import
            // 
            this.textBoxOxzFileName_import.Location = new System.Drawing.Point(20, 220);
            this.textBoxOxzFileName_import.Name = "textBoxOxzFileName_import";
            this.textBoxOxzFileName_import.Size = new System.Drawing.Size(362, 22);
            this.textBoxOxzFileName_import.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(203, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Oxz file name (without extension) :";
            // 
            // labelError_import
            // 
            this.labelError_import.AutoSize = true;
            this.labelError_import.Location = new System.Drawing.Point(58, 361);
            this.labelError_import.Name = "labelError_import";
            this.labelError_import.Size = new System.Drawing.Size(0, 16);
            this.labelError_import.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "BEFOR IMPORT :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(407, 64);
            this.label8.TabIndex = 12;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Game Folder Path :";
            // 
            // textBoxGameFolderPath
            // 
            this.textBoxGameFolderPath.Location = new System.Drawing.Point(20, 176);
            this.textBoxGameFolderPath.Name = "textBoxGameFolderPath";
            this.textBoxGameFolderPath.Size = new System.Drawing.Size(362, 22);
            this.textBoxGameFolderPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "IMPORT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelIDs_export;
        private System.Windows.Forms.TextBox textBoxIDs_export;
        private System.Windows.Forms.TextBox textBoxEditorGameFolderPath_export;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxOxzName_export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelError_Export;
        private System.Windows.Forms.TextBox textBoxGameFolderPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelError_import;
        private System.Windows.Forms.TextBox textBoxOxzFileName_import;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxDeleteOldTransFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}

