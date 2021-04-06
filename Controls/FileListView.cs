using Controls.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TwoLayeredGUI;
using TwoLayeredGUI.SimpleDialogs;
using TwoLayeredGUI.WinForms;

namespace AxCommander.Controls {
    public class FileListView : ListView {
        private static ImageList _imageList;        

        static FileListView() {
            _imageList = new ImageList {
                ImageSize = new Size( 16, 16 )
            };
            _imageList.Images.Add( Resources.folder_4046 );
            _imageList.Images.Add( Resources.unknown_7110 );
            _imageList.Images.Add( Resources.archiv );
            _imageList.Images.Add( Resources.application_x_ms_dos_executable_8240 );
            _imageList.Images.Add( Resources.fileview_preview_3605 );
            _imageList.Images.Add( Resources.pdf );
            _imageList.Images.Add( Resources.csharp );
            _imageList.Images.Add( Resources.audio );
            _imageList.Images.Add( Resources.ini );
        }

        private DirectoryInfo _currentDirectory;
        private DirectoryInfo _lastDirectory;

        private bool _showFiles = true;
        private bool _showFolders = true;
        private bool _showHidden = true;
        private bool _shiftPressed = false;
        private int _lastSelectedIndex = 0;
        private string _textFilter = string.Empty;

        public DirectoryInfo CurrentDirectory {
            get => _currentDirectory;
            set {
                _lastDirectory = _currentDirectory;
                _currentDirectory = value;
                FillListView();
            }
        }

        public int FoldersCount { get; private set; }
        public int FilesCount { get; private set; }
        public long TotalFilesSize { get; private set; } = 0;
        public string TotalFilesSizeString => AdvancedListViewItem.GetHumanReadableSize( TotalFilesSize );

        public bool ShowFiles {
            get => _showFiles;
            set {
                if ( _showFiles != value ) {
                    _showFiles = value;
                    FillListView();
                }

            }
        }
        public bool ShowFolders {
            get => _showFolders;
            set {
                if ( _showFolders != value ) {
                    _showFolders = value;
                    FillListView();
                }

            }
        }

        public bool ShowHidden {
            get => _showHidden;
            set {
                if ( _showHidden != value ) {
                    _showHidden = value;
                    FillListView();
                }

            }
        }

        public event Action OnDirectoryChanged;
        public event Action OnFileSystemChanged;

        public FileListView() {
            Clear();
            SetStyle( ControlStyles.OptimizedDoubleBuffer, true );

            View = View.Details;
            FullRowSelect = true;
            SmallImageList = _imageList;
            MultiSelect = false;
            HideSelection = false;

            var nameColumn = Columns.Add( "Name" );
            nameColumn.Width = 260;

            Columns.Add( "Size" );

            var dateColumn = Columns.Add( "Date" );
            dateColumn.Width = 100;

            Columns.Add( "Attributes" );

            base.Items.Clear();
            CurrentDirectory = new DirectoryInfo( Directory.GetCurrentDirectory() );

            MouseDoubleClick += MouseEventHandler;
            MouseClick += FileListView_MouseClick;
            MouseUp += FileListView_MouseUp;

            ColumnClick += FileListView_ColumnClick;
            KeyUp += FileListView_KeyUp;
            ItemActivate += FileListView_ItemActivate;
            Resize += FileListView_Resize;
            SelectedIndexChanged += FileListView_SelectedIndexChanged;
            LostFocus += FileListView_LostFocus;
        }

        private void FileListView_MouseUp( object sender, MouseEventArgs e ) {
            
        }

        private void FileListView_MouseClick( object sender, MouseEventArgs e ) {
            if ( SelectedItems.Count > 0 ) {
                if ( _shiftPressed ) {
                    if ( SelectedItems[ 0 ] is AdvancedListViewItem item ) {
                        item.IsSelected = !item.IsSelected;
                    }
                }
            }
        }

        private void FileListView_LostFocus( object sender, EventArgs e ) {
            _shiftPressed = false;
        }        

        private void FileListView_SelectedIndexChanged( object sender, EventArgs e ) {
            if ( SelectedItems.Count > 0 ) {
                int selectedIndex = SelectedItems[ 0 ].Index;                

                if ( _shiftPressed ) {
                    int startIndex = selectedIndex;
                    int endIndex = _lastSelectedIndex;

                    if ( selectedIndex > _lastSelectedIndex ) {
                        startIndex = _lastSelectedIndex;
                        endIndex = selectedIndex;
                    }
                    
                    for ( int i = startIndex; i < endIndex; i++ ) {
                        if ( base.Items[ i ] is AdvancedListViewItem item ) {
                            item.IsSelected = !item.IsSelected;
                        }
                    }
                }

                _lastSelectedIndex = selectedIndex;
            }
        }

        private void FileListView_ItemActivate( object sender, EventArgs e ) {
            
        }

        private void FileListView_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
        }

        private void FileListView_Resize(object sender, EventArgs e)
        {
            Columns[0].Width = Width - Columns[1].Width - Columns[2].Width - Columns[3].Width;
        }

        private void FileListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if ( e.Column == 0 )
            {
                SortOrder = SortOrder == SortOder.ByName ? SortOder.ByNameDesc : SortOder.ByName;
                Reload();
            }
            if (e.Column == 1)
            {
                SortOrder = SortOrder == SortOder.BySize ? SortOder.BySizeDesc : SortOder.BySize;
                Reload();
            }
            if (e.Column == 2)
            {
                SortOrder = SortOrder == SortOder.ByDate ? SortOder.ByDateDesc : SortOder.ByDate;
                Reload();
            }
        }

        public void ApplayTextFilter( string filterText ) {
            _textFilter = $"*{filterText}*";
            FillListView();
        }

        public bool CreateDirectory( string directoryName ) {
            if ( !string.IsNullOrEmpty( directoryName ) ) {
                if ( !Directory.Exists( Path.Combine( CurrentDirectory.FullName, directoryName ) ) ) {
                    DirectoryInfo directory = Directory.CreateDirectory( Path.Combine( CurrentDirectory.FullName, directoryName ) );

                    if ( directory != null && directory.Exists ) {
                        AddDirectoryItem(directory);
                    }
                }
                else {
                    TwoLayeredGUI.WinForms.MessageBox.Show( $"Папка {directoryName} уже существует в целевом катологе", ButtonDef.OkButton );
                }
            }

            return false;
        }

        public void DeleteSelectedItems() {
            DeleteSelected();
        }

        public void Reload() {
            FillListView();
        }

        public IEnumerable<FileSystemInfo> GetSelectedInfos()
        {
            List<FileSystemInfo> fileSystemInfos = new List<FileSystemInfo>();

            foreach( ListViewItem lvitem in base.Items )
            {
                if (lvitem is AdvancedListViewItem item && item.IsSelected)
                    fileSystemInfos.Add(item.FileSystemInfo);
            }

            if (fileSystemInfos.Count == 0 && SelectedItems.Count > 0 && SelectedItems[0] is AdvancedListViewItem selectedItem)
                fileSystemInfos.Add(selectedItem.FileSystemInfo);

            return fileSystemInfos;
        }

        /// <summary>
        /// Копирование указанных файлов или папок в текущую папку
        /// </summary>
        /// <param name="infos"></param>
        public void CopyFileSystemInfos(IEnumerable<FileSystemInfo> infos)
        {
            foreach( FileSystemInfo info in infos)
            {
                if (info.Exists)
                {
                    if (info is DirectoryInfo directory)
                    {
                        DirectoryCopy(directory, CurrentDirectory, true);
                        AddDirectoryItem(new DirectoryInfo(Path.Combine(CurrentDirectory.FullName, directory.Name)));
                    }
                    if (info is FileInfo file)
                    {
                        File.Copy(file.FullName, Path.Combine(CurrentDirectory.FullName, file.Name));
                        AddFileItem(new FileInfo(Path.Combine(CurrentDirectory.FullName, file.Name)));
                    }
                }
            }
        }

        public void RenameFileSystemInfo()
        {
            if (SelectedItems.Count > 0)
            {
                if (!(SelectedItems[0] is AdvancedListViewItem item))
                    return;

                FileSystemInfo info = item.FileSystemInfo;

                if (info.Exists)
                {
                    if (info is DirectoryInfo directory)
                    {
                        var parentLayer = new FormContainerElement();

                        var directoryInput = new TextInputElement {
                            Label = "Имя папки: ",
                            Text = info.Name
                        };

                        parentLayer.ChildElements.Add(directoryInput);

                        var dialog = DialogBox.Create("Ввод имени папки:", parentLayer, ButtonDef.OkCancelButtons);
                        dialog.AutoSize = false;
                        dialog.Width = 360;

                        if (dialog.ShowDialog() == ButtonDef.OkButton && directoryInput.Text != directory.Name)
                        {
                            if (!Directory.Exists(Path.Combine(directory.Parent.FullName, directoryInput.Text)))
                            {
                                Directory.Move(directory.FullName, Path.Combine(directory.Parent.FullName, directoryInput.Text));
                                item.FileSystemInfo = new DirectoryInfo(Path.Combine(directory.Parent.FullName, directoryInput.Text));
                                item.Text = item.FileSystemInfo.Name;
                            }

                        }
                    }
                    if (info is FileInfo file)
                    {
                        var parentLayer = new FormContainerElement();

                        var directoryInput = new TextInputElement {
                            Label = "Имя файла: ",
                            Text = info.Name
                        };

                        parentLayer.ChildElements.Add(directoryInput);

                        var dialog = DialogBox.Create("Ввод имени файла:", parentLayer, ButtonDef.OkCancelButtons);
                        dialog.AutoSize = false;
                        dialog.Width = 360;

                        if (dialog.ShowDialog() == ButtonDef.OkButton && directoryInput.Text != file.Name)
                        {
                            if (!File.Exists(Path.Combine(file.Directory.FullName, directoryInput.Text)))
                            {
                                File.Move(file.FullName, Path.Combine(file.Directory.FullName, directoryInput.Text));
                                item.FileSystemInfo = new FileInfo(Path.Combine(file.Directory.FullName, directoryInput.Text));
                                item.Text = item.FileSystemInfo.Name;
                            }

                        }
                    }
                }
            }
        }

        public void MoveFileSystemInfos(IEnumerable<FileSystemInfo> infos)
        {
            foreach (FileSystemInfo info in infos)
            {
                if (info.Exists)
                {
                    if (info is DirectoryInfo directory)
                    {
                        if (Directory.Exists(Path.Combine(CurrentDirectory.FullName, directory.Name))) {
                            TwoLayeredGUI.WinForms.MessageBox.Show($"Папка {directory.Name} уже существует в целевом катологе", ButtonDef.OkButton);
                            return;
                        }

                        directory.MoveTo( Path.Combine( CurrentDirectory.FullName, directory.Name ) );
                        AddDirectoryItem(new DirectoryInfo(Path.Combine(CurrentDirectory.FullName, directory.Name)));
                    }
                    if (info is FileInfo file)
                    {
                        File.Move(file.FullName, Path.Combine(CurrentDirectory.FullName, file.Name));
                        AddFileItem(new FileInfo(Path.Combine(CurrentDirectory.FullName, file.Name)));
                    }
                }
            }
        }

        public void GoBack()
        {
            if ( _lastDirectory != null && _lastDirectory.Exists )
            {
                CurrentDirectory = _lastDirectory;
            }
        }

        private void FillListView() {
            FoldersCount = 0;
            FilesCount = 0;
            TotalFilesSize = 0;

            base.Items.Clear();

            if ( CurrentDirectory.Parent != null && CurrentDirectory.Parent.Exists )
                base.Items.Add( ".." );

            if ( CurrentDirectory != null && CurrentDirectory.Exists ) {

                if ( ShowFolders ) {
                    IEnumerable<DirectoryInfo> directories = null;

                    try
                    {
                        directories = string.IsNullOrEmpty( _textFilter ) ? CurrentDirectory.GetDirectories() : CurrentDirectory.GetDirectories( _textFilter );
                    }
                    catch( Exception exception)
                    {
                        TwoLayeredGUI.WinForms.MessageBox.Show( "Ошибка доступа к папке", exception.Message, ButtonDef.OkButton);
                    }

                    if (directories == null)
                        return;


                    if (SortOrder == SortOder.ByName || SortOrder == SortOder.BySize || SortOrder == SortOder.BySizeDesc)
                    {
                        foreach (var directory in directories.OrderBy(d => d.Name))
                        {
                            AddDirectoryItem(directory);
                        }
                    }
                    if (SortOrder == SortOder.ByNameDesc)
                    {
                        foreach (var directory in directories.OrderByDescending(d => d.Name))
                        {
                            AddDirectoryItem(directory);
                        }
                    }
                    if (SortOrder == SortOder.ByDate)
                    {
                        foreach (var directory in directories.OrderBy(d => d.LastAccessTime))
                        {
                            AddDirectoryItem(directory);
                        }
                    }
                    if (SortOrder == SortOder.ByDateDesc)
                    {
                        foreach (var directory in directories.OrderByDescending(d => d.LastAccessTime))
                        {
                            AddDirectoryItem(directory);
                        }
                    }
                }

                if ( ShowFiles ) {
                    string searchPattern = string.IsNullOrEmpty( _textFilter ) ? "*" : _textFilter;
                    if (SortOrder == SortOder.ByName)
                    {
                        foreach (var file in CurrentDirectory.GetFiles( searchPattern, SearchOption.TopDirectoryOnly).OrderBy(f => f.Name))
                        {
                            AddFileItem(file);
                        }
                    }
                    if (SortOrder == SortOder.ByNameDesc)
                    {
                        foreach (var file in CurrentDirectory.GetFiles( searchPattern, SearchOption.TopDirectoryOnly).OrderByDescending(f => f.Name))
                        {
                            AddFileItem(file);
                        }
                    }
                    if (SortOrder == SortOder.ByDate)
                    {
                        foreach (var file in CurrentDirectory.GetFiles( searchPattern, SearchOption.TopDirectoryOnly).OrderBy(f => f.LastAccessTime))
                        {
                            AddFileItem(file);
                        }
                    }
                    if (SortOrder == SortOder.ByDateDesc)
                    {
                        foreach (var file in CurrentDirectory.GetFiles( searchPattern, SearchOption.TopDirectoryOnly).OrderByDescending(f => f.LastAccessTime))
                        {
                            AddFileItem(file);
                        }
                    }
                    if (SortOrder == SortOder.BySize)
                    {
                        foreach (var file in CurrentDirectory.GetFiles( searchPattern, SearchOption.TopDirectoryOnly).OrderBy(f => f.Length))
                        {
                            AddFileItem(file);
                        }
                    }
                    if (SortOrder == SortOder.BySizeDesc)
                    {
                        foreach (var file in CurrentDirectory.GetFiles( searchPattern, SearchOption.TopDirectoryOnly).OrderByDescending(f => f.Length))
                        {
                            AddFileItem(file);
                        }
                    }
                }
            }

            if ( base.Items.Count > 0 ) {
                base.Items[ 0 ].Selected = true;
                base.Items[ 0 ].Focused = true;
            }

            OnDirectoryChanged?.Invoke();
        }

        private void AddDirectoryItem( DirectoryInfo directory )
        {
            if (!ShowHidden)
            {
                if (directory.Attributes.HasFlag(FileAttributes.Hidden))
                    return;
            }

            if (!ShowFolders)
            {
                return;
            }

            FoldersCount++;

            var item = new AdvancedListViewItem(directory);
            item.ImageIndex = 0;

            base.Items.Add(item);
        }

        private void AddFileItem(FileInfo file)
        {
            if (!ShowHidden)
            {
                if (file.Attributes.HasFlag(FileAttributes.Hidden))
                    return;
            }

            if (!ShowFiles)
                return;

            FilesCount++;
            TotalFilesSize += file.Length;

            var item = new AdvancedListViewItem(file);

            if (file.Extension.ToLower() == ".zip" || file.Extension.ToLower() == ".7z" || file.Extension.ToLower() == ".rar" || file.Extension.ToLower() == ".arj")
                item.ImageIndex = 2;
            else if (file.Extension.ToLower() == ".exe")
                item.ImageIndex = 3;
            else if (file.Extension.ToLower() == ".pdf")
                item.ImageIndex = 5;
            else if (file.Extension.ToLower() == ".cs")
                item.ImageIndex = 6;
            else if (file.Extension.ToLower() == ".mp3")
                item.ImageIndex = 7;
            else if (file.Extension.ToLower() == ".ini" || file.Extension.ToLower() == ".config")
                item.ImageIndex = 8;
            else if (file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".bmp" || file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".jpeg")
                item.ImageIndex = 4;
            else
                item.ImageIndex = 1;

            base.Items.Add(item);
        }

        public new ListViewItemCollection Items => new ListViewItemCollection( new ListView() );

        public SortOder SortOrder { get; set; } = SortOder.ByName;

        //protected override void OnDoubleClick( EventArgs e ) {            
        //    ItemAction();
        //}

        public void MouseEventHandler( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left )
                ItemAction();
        }

        protected override void OnKeyPress( KeyPressEventArgs e ) {
            if ( e.KeyChar == 13 ) {
                ItemAction();
            }
        }       

        protected override void OnKeyDown( KeyEventArgs e ) {
            if ( e.KeyData == ( Keys.Shift | Keys.ShiftKey ) ) {
                _shiftPressed = true;
            }

            Debug.Print( e.KeyData.ToString() );
        }

        protected override void OnKeyUp( KeyEventArgs e ) {
            if ( e.KeyData == Keys.Delete ) {
                DeleteSelected();
            }

            if ( e.KeyData == ( Keys.ShiftKey ) )
                _shiftPressed = false;

            if ( e.KeyData == ( Keys.Shift | Keys.Down ) && SelectedItems.Count > 0 && SelectedItems[ 0 ].Index == base.Items.Count - 1 ) {
                if ( SelectedItems[ 0 ] is AdvancedListViewItem item ) {
                    item.IsSelected = !item.IsSelected;
                }
            }

            if ( e.KeyData == ( Keys.Shift | Keys.Up ) && SelectedItems.Count > 0 && SelectedItems[ 0 ].Index == base.Items.Count - 1 ) {
                if ( SelectedItems[ 0 ] is AdvancedListViewItem item ) {
                    item.IsSelected = !item.IsSelected;
                }
            }

            Debug.Print( e.KeyData.ToString() );
        }

        private void DeleteSelected() {
            if ( SelectedItems.Count > 0 ) {
                if ( SelectedItems[ 0 ] is AdvancedListViewItem advancedListViewItem ) {
                    if ( Environment.OSVersion.VersionString.ToLower().Contains( "windows" ) ) {
                        if ( WindowsNative.MoveFileToRecycleBin( advancedListViewItem.FileSystemInfo.FullName ) ) {
                            if ( advancedListViewItem.FileSystemType == FileSystemType.LocalDirectory ) {
                                FoldersCount--;
                            }
                            if ( advancedListViewItem.FileSystemType == FileSystemType.LocalFile ) {
                                FilesCount--;
                            }

                            base.Items.Remove( advancedListViewItem );
                            OnFileSystemChanged?.Invoke();
                        }
                        else {
                            TwoLayeredGUI.WinForms.MessageBox.Show( $"Ошибка при удалении файла {advancedListViewItem.FileSystemInfo.Name}" );
                        }
                    }
                }
            }
        }

        private void ItemAction() {
            if ( SelectedItems.Count > 0 ) {
                if ( SelectedItems[ 0 ].Text == ".." && CurrentDirectory != null ) {
                    var parentDirectory = CurrentDirectory.Parent;

                    if ( parentDirectory != null && parentDirectory.Exists )
                        CurrentDirectory = parentDirectory;

                    return;
                }

                if ( SelectedItems[ 0 ] is AdvancedListViewItem advancedListViewItem ) {
                    if ( advancedListViewItem.FileSystemType == FileSystemType.LocalDirectory ) {
                        if ( advancedListViewItem.FileSystemInfo is DirectoryInfo directory )
                            CurrentDirectory = directory;
                    }
                    if ( advancedListViewItem.FileSystemType == FileSystemType.LocalFile ) {
                        if (advancedListViewItem.FileSystemInfo is FileInfo file)
                            try
                            {
                                Process.Start(file.FullName);
                            }
                            catch( Exception exception)
                            {
                                TwoLayeredGUI.WinForms.MessageBox.Show(exception.Message);
                            }
                    }
                }
            }
        }

        /// TODO: перенести в хэлпер
        /// <summary>
        /// Метод копирования папок с подпапками, скачанный из нэта
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destDirectory"></param>
        /// <param name="copySubDirs"></param>
        private static void DirectoryCopy( DirectoryInfo sourceDirectory, DirectoryInfo destDirectory, bool copySubDirs)
        {
            DirectoryInfo newDirectory = new DirectoryInfo(Path.Combine(destDirectory.FullName, sourceDirectory.Name));

            if (!sourceDirectory.Exists)
            {
                throw new DirectoryNotFoundException();
            }

            DirectoryInfo[] directories = sourceDirectory.GetDirectories();
      
            newDirectory.Create();
            
            FileInfo[] files = sourceDirectory.GetFiles();
            
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(newDirectory.FullName, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subDirectory in directories)
                {
                    DirectoryInfo newSubDirectory = new DirectoryInfo(Path.Combine(newDirectory.FullName, subDirectory.Name));
                    DirectoryCopy(subDirectory, newSubDirectory, copySubDirs);
                }
            }
        }
    }
}
