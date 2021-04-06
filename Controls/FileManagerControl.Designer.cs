namespace AxCommander.Controls {
    partial class FileManagerControl {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerControl));
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxCurrentDirectory = new System.Windows.Forms.TextBox();
            this.checkBoxShowHiddenElements = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFolders = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFiles = new System.Windows.Forms.CheckBox();
            this.fileListView1 = new AxCommander.Controls.FileListView();
            this.driveComboBox1 = new ZinoLib.Windows.Controls.DriveComboBox();
            this.buttonGoTop = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.Location = new System.Drawing.Point(3, 421);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(331, 20);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Папок: Файлов: Общ.размер файлов:";
            // 
            // textBoxCurrentDirectory
            // 
            this.textBoxCurrentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentDirectory.Location = new System.Drawing.Point(189, 8);
            this.textBoxCurrentDirectory.Name = "textBoxCurrentDirectory";
            this.textBoxCurrentDirectory.Size = new System.Drawing.Size(56, 20);
            this.textBoxCurrentDirectory.TabIndex = 3;
            this.textBoxCurrentDirectory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCurrentDirectory_KeyPress);
            // 
            // checkBoxShowHiddenElements
            // 
            this.checkBoxShowHiddenElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowHiddenElements.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowHiddenElements.Image = global::Controls.Properties.Resources.iconfinder_icon_21_eye_hidden_314753;
            this.checkBoxShowHiddenElements.Location = new System.Drawing.Point(248, 3);
            this.checkBoxShowHiddenElements.Name = "checkBoxShowHiddenElements";
            this.checkBoxShowHiddenElements.Size = new System.Drawing.Size(28, 28);
            this.checkBoxShowHiddenElements.TabIndex = 5;
            this.checkBoxShowHiddenElements.TabStop = false;
            this.checkBoxShowHiddenElements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowHiddenElements.UseVisualStyleBackColor = true;
            this.checkBoxShowHiddenElements.CheckedChanged += new System.EventHandler(this.checkBoxShowHidden_CheckedChanged);
            // 
            // checkBoxShowFolders
            // 
            this.checkBoxShowFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowFolders.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowFolders.Image = global::Controls.Properties.Resources.folder_4046;
            this.checkBoxShowFolders.Location = new System.Drawing.Point(277, 3);
            this.checkBoxShowFolders.Name = "checkBoxShowFolders";
            this.checkBoxShowFolders.Size = new System.Drawing.Size(28, 28);
            this.checkBoxShowFolders.TabIndex = 6;
            this.checkBoxShowFolders.TabStop = false;
            this.checkBoxShowFolders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowFolders.UseVisualStyleBackColor = true;
            this.checkBoxShowFolders.CheckedChanged += new System.EventHandler(this.checkBoxShowFolders_CheckedChanged);
            // 
            // checkBoxShowFiles
            // 
            this.checkBoxShowFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowFiles.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxShowFiles.Image = global::Controls.Properties.Resources.unknown_7110;
            this.checkBoxShowFiles.Location = new System.Drawing.Point(306, 3);
            this.checkBoxShowFiles.Name = "checkBoxShowFiles";
            this.checkBoxShowFiles.Size = new System.Drawing.Size(28, 28);
            this.checkBoxShowFiles.TabIndex = 7;
            this.checkBoxShowFiles.TabStop = false;
            this.checkBoxShowFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowFiles.UseVisualStyleBackColor = true;
            this.checkBoxShowFiles.CheckedChanged += new System.EventHandler(this.checkBoxShowFiles_CheckedChanged);
            // 
            // fileListView1
            // 
            this.fileListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView1.CurrentDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("fileListView1.CurrentDirectory")));
            this.fileListView1.FullRowSelect = true;
            this.fileListView1.HideSelection = false;
            this.fileListView1.Location = new System.Drawing.Point(3, 37);
            this.fileListView1.MultiSelect = false;
            this.fileListView1.Name = "fileListView1";
            this.fileListView1.ShowFiles = true;
            this.fileListView1.ShowFolders = true;
            this.fileListView1.ShowHidden = true;
            this.fileListView1.Size = new System.Drawing.Size(331, 381);
            this.fileListView1.SortOrder = AxCommander.Controls.SortOder.ByName;
            this.fileListView1.TabIndex = 0;
            this.fileListView1.UseCompatibleStateImageBehavior = false;
            this.fileListView1.View = System.Windows.Forms.View.Details;
            this.fileListView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fileListView1_KeyPress);
            this.fileListView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fileListView1_KeyUp);
            // 
            // driveComboBox1
            // 
            this.driveComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.driveComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveComboBox1.FormattingEnabled = true;
            this.driveComboBox1.Location = new System.Drawing.Point(33, 8);
            this.driveComboBox1.Name = "driveComboBox1";
            this.driveComboBox1.Size = new System.Drawing.Size(152, 21);
            this.driveComboBox1.TabIndex = 2;
            this.driveComboBox1.SelectedIndexChanged += new System.EventHandler(this.driveComboBox1_SelectedIndexChanged);
            // 
            // buttonGoTop
            // 
            this.buttonGoTop.Image = global::Controls.Properties.Resources.go_top_1715;
            this.buttonGoTop.Location = new System.Drawing.Point(2, 3);
            this.buttonGoTop.Name = "buttonGoTop";
            this.buttonGoTop.Size = new System.Drawing.Size(28, 28);
            this.buttonGoTop.TabIndex = 4;
            this.buttonGoTop.TabStop = false;
            this.buttonGoTop.UseVisualStyleBackColor = true;
            this.buttonGoTop.Click += new System.EventHandler(this.buttonGoTop_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(306, 420);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(28, 20);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            this.textBoxFilter.Enter += new System.EventHandler(this.textBoxFilter_Enter);
            this.textBoxFilter.Leave += new System.EventHandler(this.textBoxFilter_Leave);
            // 
            // FileManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.buttonGoTop);
            this.Controls.Add(this.driveComboBox1);
            this.Controls.Add(this.textBoxCurrentDirectory);
            this.Controls.Add(this.checkBoxShowHiddenElements);
            this.Controls.Add(this.checkBoxShowFolders);
            this.Controls.Add(this.checkBoxShowFiles);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.fileListView1);
            this.DoubleBuffered = true;
            this.Name = "FileManagerControl";
            this.Size = new System.Drawing.Size(337, 441);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FileListView fileListView1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.CheckBox checkBoxShowFiles;
        private System.Windows.Forms.CheckBox checkBoxShowFolders;
        private System.Windows.Forms.TextBox textBoxCurrentDirectory;
        private System.Windows.Forms.CheckBox checkBoxShowHiddenElements;
        //private RootsComboBox rootsComboBox1;
        //private RootsComboBox rootsComboBox2;
        //private RootsComboBox rootsComboBox3;
        //private RootsComboBox rootsComboBox4;
        private ZinoLib.Windows.Controls.DriveComboBox driveComboBox1;
        private System.Windows.Forms.Button buttonGoTop;
        private System.Windows.Forms.TextBox textBoxFilter;
    }
}
