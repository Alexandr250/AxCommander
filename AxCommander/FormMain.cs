using AxCommander.Controls;
using Be.HexEditor;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AxCommander
{
    public partial class FormMain : Form {
        FileManagerControl _currentFileManager;
        private Keys? _keys = null;

        public FormMain() {
            InitializeComponent();
            _currentFileManager = fileManagerControl1;
            fileManagerControl1.Select();
        }

        private void Form1_Load( object sender, EventArgs e ) {
            //fileManagerControl1.CreateDirectory();
        }

        private void fileManagerControl1_Click( object sender, EventArgs e ) {
            _currentFileManager = fileManagerControl1;
        }

        private void fileManagerControl2_Click( object sender, EventArgs e ) {
            _currentFileManager = fileManagerControl2;
        }

        private void fileManagerControl1_Enter( object sender, EventArgs e ) {
            _currentFileManager = fileManagerControl1;
        }

        private void fileManagerControl2_Enter( object sender, EventArgs e ) {
            _currentFileManager = fileManagerControl2;
        }

        private void buttonNewFolder_Click( object sender, EventArgs e ) {
            _currentFileManager.CreateDirectory();
        }

        private void buttonF3FunctionalButton_Click(object sender, EventArgs e)
        {
            if (!_keys.HasValue)
            {
                var ApplictionForm = new FormHexEditor();
                var selectedInfos = _currentFileManager.GetSelectedInfos();
                if (selectedInfos != null && selectedInfos.Count() > 0)
                {
                    if (selectedInfos.First() is FileInfo fileInfo)
                    {
                        ApplictionForm.OpenFile(fileInfo.FullName);
                        ApplictionForm.Show();
                    }
                }
            }
        }

        private void buttonF5FunctionalButton_Click(object sender, EventArgs e)
        {
            if (!_keys.HasValue)
            {
                FileManagerControl additionalFileManager = _currentFileManager == fileManagerControl1 ? fileManagerControl2 : fileManagerControl1;
                additionalFileManager.CopyFileSystemInfos(_currentFileManager.GetSelectedInfos());
            }
        }

        private void buttonF6FunctionalButton_Click(object sender, EventArgs e)
        {
            if (!_keys.HasValue)
            {
                FileManagerControl additionalFileManager = _currentFileManager == fileManagerControl1 ? fileManagerControl2 : fileManagerControl1;
                additionalFileManager.MoveFileSystemInfos(_currentFileManager.GetSelectedInfos());
                _currentFileManager.Reload();
            }
            if (_keys.HasValue && _keys.Value == Keys.ShiftKey)
            {
                renameCurrentToolStripMenuItem_Click(sender, e);
                _keys = null;
                ChangeFunctionalButtonsCaptions(_keys);
            }
        }

        private void buttonF8FunctionalButton_Click( object sender, EventArgs e ) {
            if (!_keys.HasValue)
            {
                _currentFileManager.DeleteSelectedItems();
            }
        }

        private void buttonF9FunctionalButton_Click(object sender, EventArgs e)
        {
            if (!_keys.HasValue)
            {
                _currentFileManager.Reload();
            }
            if (_keys.HasValue && _keys.Value == Keys.ShiftKey)
            {
                Close();
            }
        }        

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {}

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                    ChangeFunctionalButtonsCaptions(Keys.ShiftKey);
                    _keys = Keys.ShiftKey;
                    break;
            }
        }

        private void FormMain_KeyUp( object sender, KeyEventArgs e ) {
            switch ( e.KeyCode ) {
                //case Keys.Oemplus:
                //    ToolStripMenuItemSincronizePanels_Click(sender, null);
                //    break;
                case Keys.F3:
                    buttonF3FunctionalButton_Click( sender, null );
                    break;
                case Keys.F5:
                    buttonF5FunctionalButton_Click( sender, null );
                    break;
                case Keys.F6:
                    buttonF6FunctionalButton_Click( sender, null );
                    break;
                case Keys.F8:
                    buttonF8FunctionalButton_Click( sender, null );
                    break;
                case Keys.F9:
                    buttonF9FunctionalButton_Click( sender, null );
                    break;
                case Keys.Back:
                    if ( !_currentFileManager.InputEnabled )
                        _currentFileManager.GoToParent();
                    break;
                case Keys.ShiftKey:
                    ChangeFunctionalButtonsCaptions( null );
                    _keys = null;
                    break;
            }
        }

        private void ToolStripMenuItemSincronizePanels_Click(object sender, EventArgs e)
        {
            if (_currentFileManager == fileManagerControl1)
                fileManagerControl2.CurrentDirectory = fileManagerControl1.CurrentDirectory;
            else
                fileManagerControl1.CurrentDirectory = fileManagerControl2.CurrentDirectory;
        }

        private void renameCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentFileManager.RenameItem();
        }

        private void ChangeFunctionalButtonsCaptions( Keys? keys )
        {
            if (!keys.HasValue)
            {
                buttonF3FunctionalButton.Text = "F3 Просмотр";
                buttonF4FunctionalButton.Text = "F4 Правка";
                buttonF5FunctionalButton.Text = "F5 Копирование";
                buttonF6FunctionalButton.Text = "F6 Перемещение";
                buttonF7FunctionalButton.Text = "F7 Каталог";
                buttonF8FunctionalButton.Text = "F8 Удаление";
                buttonF9FunctionalButton.Text = "F9 Обновить";
            }
            if (keys.HasValue && keys.Value == Keys.ShiftKey)
            {
                buttonF3FunctionalButton.Text = "";
                buttonF4FunctionalButton.Text = "";
                buttonF5FunctionalButton.Text = "";
                buttonF6FunctionalButton.Text = "F6 Переименование";
                buttonF7FunctionalButton.Text = "";
                buttonF8FunctionalButton.Text = "";
                buttonF9FunctionalButton.Text = "F9 Выход";
            }
        }

        private void ToolStripMenuItemGoBack_Click(object sender, EventArgs e)
        {
            _currentFileManager.GoBack();
        }
    }
} 
