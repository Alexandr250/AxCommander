namespace AxCommander {
    partial class FormMain {
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fileManagerControl1 = new AxCommander.Controls.FileManagerControl();
            this.fileManagerControl2 = new AxCommander.Controls.FileManagerControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.командыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSincronizePanels = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonF3FunctionalButton = new System.Windows.Forms.Button();
            this.buttonF9FunctionalButton = new System.Windows.Forms.Button();
            this.buttonF4FunctionalButton = new System.Windows.Forms.Button();
            this.buttonF8FunctionalButton = new System.Windows.Forms.Button();
            this.buttonF5FunctionalButton = new System.Windows.Forms.Button();
            this.buttonF7FunctionalButton = new System.Windows.Forms.Button();
            this.buttonF6FunctionalButton = new System.Windows.Forms.Button();
            this.ToolStripMenuItemGoBack = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileManagerControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileManagerControl2);
            this.splitContainer1.Size = new System.Drawing.Size(781, 422);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // fileManagerControl1
            // 
            this.fileManagerControl1.CurrentDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("fileManagerControl1.CurrentDirectory")));
            this.fileManagerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileManagerControl1.Location = new System.Drawing.Point(0, 0);
            this.fileManagerControl1.Name = "fileManagerControl1";
            this.fileManagerControl1.Size = new System.Drawing.Size(374, 422);
            this.fileManagerControl1.TabIndex = 0;
            this.fileManagerControl1.Click += new System.EventHandler(this.fileManagerControl1_Click);
            this.fileManagerControl1.Enter += new System.EventHandler(this.fileManagerControl1_Enter);
            // 
            // fileManagerControl2
            // 
            this.fileManagerControl2.CurrentDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("fileManagerControl2.CurrentDirectory")));
            this.fileManagerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileManagerControl2.Location = new System.Drawing.Point(0, 0);
            this.fileManagerControl2.Name = "fileManagerControl2";
            this.fileManagerControl2.Size = new System.Drawing.Size(403, 422);
            this.fileManagerControl2.TabIndex = 0;
            this.fileManagerControl2.Click += new System.EventHandler(this.fileManagerControl2_Click);
            this.fileManagerControl2.Enter += new System.EventHandler(this.fileManagerControl2_Enter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.выделениеToolStripMenuItem,
            this.командыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameCurrentToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // renameCurrentToolStripMenuItem
            // 
            this.renameCurrentToolStripMenuItem.Image = global::AxCommander.Properties.Resources.rename;
            this.renameCurrentToolStripMenuItem.Name = "renameCurrentToolStripMenuItem";
            this.renameCurrentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F6)));
            this.renameCurrentToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.renameCurrentToolStripMenuItem.Text = "Переименовать текущее...";
            this.renameCurrentToolStripMenuItem.Click += new System.EventHandler(this.renameCurrentToolStripMenuItem_Click);
            // 
            // выделениеToolStripMenuItem
            // 
            this.выделениеToolStripMenuItem.Name = "выделениеToolStripMenuItem";
            this.выделениеToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.выделениеToolStripMenuItem.Text = "Выделение";
            // 
            // командыToolStripMenuItem
            // 
            this.командыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSincronizePanels,
            this.ToolStripMenuItemGoBack});
            this.командыToolStripMenuItem.Name = "командыToolStripMenuItem";
            this.командыToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.командыToolStripMenuItem.Text = "Команды";
            // 
            // ToolStripMenuItemSincronizePanels
            // 
            this.ToolStripMenuItemSincronizePanels.Name = "ToolStripMenuItemSincronizePanels";
            this.ToolStripMenuItemSincronizePanels.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.ToolStripMenuItemSincronizePanels.Size = new System.Drawing.Size(294, 22);
            this.ToolStripMenuItemSincronizePanels.Text = "Получатель = источнику";
            this.ToolStripMenuItemSincronizePanels.Click += new System.EventHandler(this.ToolStripMenuItemSincronizePanels_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.buttonF3FunctionalButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonF9FunctionalButton, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonF4FunctionalButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonF8FunctionalButton, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonF5FunctionalButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonF7FunctionalButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonF6FunctionalButton, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 455);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 33);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonF3FunctionalButton
            // 
            this.buttonF3FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF3FunctionalButton.Location = new System.Drawing.Point(3, 3);
            this.buttonF3FunctionalButton.Name = "buttonF3FunctionalButton";
            this.buttonF3FunctionalButton.Size = new System.Drawing.Size(105, 27);
            this.buttonF3FunctionalButton.TabIndex = 3;
            this.buttonF3FunctionalButton.TabStop = false;
            this.buttonF3FunctionalButton.Text = "F3 Просмотр";
            this.buttonF3FunctionalButton.UseVisualStyleBackColor = true;
            this.buttonF3FunctionalButton.Click += new System.EventHandler(this.buttonF3FunctionalButton_Click);
            // 
            // buttonF9FunctionalButton
            // 
            this.buttonF9FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF9FunctionalButton.Location = new System.Drawing.Point(669, 3);
            this.buttonF9FunctionalButton.Name = "buttonF9FunctionalButton";
            this.buttonF9FunctionalButton.Size = new System.Drawing.Size(109, 27);
            this.buttonF9FunctionalButton.TabIndex = 4;
            this.buttonF9FunctionalButton.TabStop = false;
            this.buttonF9FunctionalButton.Text = "F9 Обновить";
            this.buttonF9FunctionalButton.UseVisualStyleBackColor = true;
            this.buttonF9FunctionalButton.Click += new System.EventHandler(this.buttonF9FunctionalButton_Click);
            // 
            // buttonF4FunctionalButton
            // 
            this.buttonF4FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF4FunctionalButton.Location = new System.Drawing.Point(114, 3);
            this.buttonF4FunctionalButton.Name = "buttonF4FunctionalButton";
            this.buttonF4FunctionalButton.Size = new System.Drawing.Size(105, 27);
            this.buttonF4FunctionalButton.TabIndex = 4;
            this.buttonF4FunctionalButton.TabStop = false;
            this.buttonF4FunctionalButton.Text = "F4 Правка";
            this.buttonF4FunctionalButton.UseVisualStyleBackColor = true;
            // 
            // buttonF8FunctionalButton
            // 
            this.buttonF8FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF8FunctionalButton.Location = new System.Drawing.Point(558, 3);
            this.buttonF8FunctionalButton.Name = "buttonF8FunctionalButton";
            this.buttonF8FunctionalButton.Size = new System.Drawing.Size(105, 27);
            this.buttonF8FunctionalButton.TabIndex = 4;
            this.buttonF8FunctionalButton.TabStop = false;
            this.buttonF8FunctionalButton.Text = "F8 Удаление";
            this.buttonF8FunctionalButton.UseVisualStyleBackColor = true;
            this.buttonF8FunctionalButton.Click += new System.EventHandler(this.buttonF8FunctionalButton_Click);
            // 
            // buttonF5FunctionalButton
            // 
            this.buttonF5FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF5FunctionalButton.Location = new System.Drawing.Point(225, 3);
            this.buttonF5FunctionalButton.Name = "buttonF5FunctionalButton";
            this.buttonF5FunctionalButton.Size = new System.Drawing.Size(105, 27);
            this.buttonF5FunctionalButton.TabIndex = 4;
            this.buttonF5FunctionalButton.TabStop = false;
            this.buttonF5FunctionalButton.Text = "F5 Копирование";
            this.buttonF5FunctionalButton.UseVisualStyleBackColor = true;
            this.buttonF5FunctionalButton.Click += new System.EventHandler(this.buttonF5FunctionalButton_Click);
            // 
            // buttonF7FunctionalButton
            // 
            this.buttonF7FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF7FunctionalButton.Location = new System.Drawing.Point(447, 3);
            this.buttonF7FunctionalButton.Name = "buttonF7FunctionalButton";
            this.buttonF7FunctionalButton.Size = new System.Drawing.Size(105, 27);
            this.buttonF7FunctionalButton.TabIndex = 4;
            this.buttonF7FunctionalButton.TabStop = false;
            this.buttonF7FunctionalButton.Text = "F7 Каталог";
            this.buttonF7FunctionalButton.UseVisualStyleBackColor = true;
            this.buttonF7FunctionalButton.Click += new System.EventHandler(this.buttonNewFolder_Click);
            // 
            // buttonF6FunctionalButton
            // 
            this.buttonF6FunctionalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonF6FunctionalButton.Location = new System.Drawing.Point(336, 3);
            this.buttonF6FunctionalButton.Name = "buttonF6FunctionalButton";
            this.buttonF6FunctionalButton.Size = new System.Drawing.Size(105, 27);
            this.buttonF6FunctionalButton.TabIndex = 4;
            this.buttonF6FunctionalButton.TabStop = false;
            this.buttonF6FunctionalButton.Text = "F6 Перемещение";
            this.buttonF6FunctionalButton.UseVisualStyleBackColor = true;
            this.buttonF6FunctionalButton.Click += new System.EventHandler(this.buttonF6FunctionalButton_Click);
            // 
            // ToolStripMenuItemGoBack
            // 
            this.ToolStripMenuItemGoBack.Name = "ToolStripMenuItemGoBack";
            this.ToolStripMenuItemGoBack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left)));
            this.ToolStripMenuItemGoBack.Size = new System.Drawing.Size(294, 22);
            this.ToolStripMenuItemGoBack.Text = "Назад";
            this.ToolStripMenuItemGoBack.Click += new System.EventHandler(this.ToolStripMenuItemGoBack_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 491);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "AxCommander";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.FileManagerControl fileManagerControl1;
        private Controls.FileManagerControl fileManagerControl2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выделениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonF3FunctionalButton;
        private System.Windows.Forms.Button buttonF4FunctionalButton;
        private System.Windows.Forms.Button buttonF5FunctionalButton;
        private System.Windows.Forms.Button buttonF6FunctionalButton;
        private System.Windows.Forms.Button buttonF7FunctionalButton;
        private System.Windows.Forms.Button buttonF8FunctionalButton;
        private System.Windows.Forms.Button buttonF9FunctionalButton;
        private System.Windows.Forms.ToolStripMenuItem командыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSincronizePanels;
        private System.Windows.Forms.ToolStripMenuItem renameCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGoBack;
    }
}

