using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TwoLayeredGUI.SimpleDialogs;
using TwoLayeredGUI.WinForms;
using TwoLayeredGUI;

namespace AxCommander.Controls {
    public partial class FileManagerControl : UserControl {

        public bool InputEnabled { get; private set; } = false;
        public FileManagerControl() {
            InitializeComponent();
            fileListView1.OnDirectoryChanged += OnDirectoryChanged;
            fileListView1.OnFileSystemChanged += OnDirectoryChanged;
            OnDirectoryChanged();
            checkBoxShowFiles.Checked = fileListView1.ShowFiles;
            checkBoxShowFolders.Checked = fileListView1.ShowFolders;
            checkBoxShowHiddenElements.Checked = fileListView1.ShowHidden;
        }

        public void RenameItem()
        {
            fileListView1.RenameFileSystemInfo();
        }

        public bool CreateDirectory() {
            var parentLayer = new FormContainerElement();
            
            var directoryInput = new TextInputElement();
            directoryInput.Label = "Имя папки: ";
            directoryInput.Text = "Новая папка";

            parentLayer.ChildElements.Add( directoryInput );

            var dialog = DialogBox.Create( "Ввод имени папки:", parentLayer, ButtonDef.OkCancelButtons );
            dialog.AutoSize = false;
            dialog.Width = 360;

            if ( dialog.ShowDialog() == ButtonDef.OkButton ) {
                return fileListView1.CreateDirectory( directoryInput.Text );
            }

            return false;
        }

        public bool DeleteSelectedItems() {
            fileListView1.DeleteSelectedItems();
            return true;
        }

        public void Reload()
        {
            fileListView1.Reload();
        }

        public IEnumerable<FileSystemInfo> GetSelectedInfos()
        {
            return fileListView1.GetSelectedInfos();
        }

        public void CopyFileSystemInfos(IEnumerable<FileSystemInfo> infos)
        {
            fileListView1.CopyFileSystemInfos(infos);
        }

        public void MoveFileSystemInfos(IEnumerable<FileSystemInfo> infos)
        {
            fileListView1.MoveFileSystemInfos(infos);
        }

        private void OnDirectoryChanged() {
            labelInfo.Text = $"Папок:{fileListView1.FoldersCount} | Файлов: {fileListView1.FilesCount} | Общ.размер файлов: {fileListView1.TotalFilesSizeString}";
            textBoxCurrentDirectory.Text = fileListView1.CurrentDirectory.FullName;
        }

        private void checkBoxShowFolders_CheckedChanged( object sender, EventArgs e ) {
            fileListView1.ShowFolders = checkBoxShowFolders.Checked;
        }

        private void checkBoxShowFiles_CheckedChanged( object sender, EventArgs e ) {
            fileListView1.ShowFiles = checkBoxShowFiles.Checked;
        }

        private void checkBoxShowHidden_CheckedChanged( object sender, EventArgs e ) {
            fileListView1.ShowHidden = checkBoxShowHiddenElements.Checked;
        }

        private void textBoxCurrentDirectory_KeyPress( object sender, KeyPressEventArgs e ) {
            if ( e.KeyChar == 13 ) {
                DirectoryInfo newDirectoryInfo = new DirectoryInfo( textBoxCurrentDirectory.Text );
                if ( newDirectoryInfo.Exists )
                    fileListView1.CurrentDirectory = newDirectoryInfo;
            }
        }

        private void driveComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var item = driveComboBox1.SelectedItem as RootComboBoxItem;

            //DirectoryInfo drive = new DirectoryInfo( item.Root.Name );
            //if ( fileListView1.CurrentDirectory.FullName != drive.FullName )
            //{
            //    fileListView1.CurrentDirectory = drive;
            //}
            if (fileListView1.CurrentDirectory.FullName != driveComboBox1.SelectedDrive)
            {
                fileListView1.CurrentDirectory = new DirectoryInfo(driveComboBox1.SelectedDrive);
            }
        }

        public void buttonGoTop_Click(object sender, EventArgs e)
        {
            if (fileListView1.CurrentDirectory.Root != fileListView1.CurrentDirectory)
                fileListView1.CurrentDirectory = fileListView1.CurrentDirectory.Root;
        }

        public DirectoryInfo CurrentDirectory
        {
            get => fileListView1.CurrentDirectory;
            set => fileListView1.CurrentDirectory = value;
        }

        public void GoToParent()
        {
            var parentDirectory = fileListView1.CurrentDirectory.Parent;

            if (parentDirectory != null && parentDirectory.Exists)
                fileListView1.CurrentDirectory = parentDirectory;
        }

        public void GoBack()
        {
            fileListView1.GoBack();
        }

        private void fileListView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void fileListView1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBoxFilter_TextChanged( object sender, EventArgs e ) {
            fileListView1.ApplayTextFilter( textBoxFilter.Text );
        }

        private void textBoxFilter_Enter(object sender, EventArgs e)
        {
            InputEnabled = true;
        }

        private void textBoxFilter_Leave(object sender, EventArgs e)
        {
            InputEnabled = false;
        }
    }
}
