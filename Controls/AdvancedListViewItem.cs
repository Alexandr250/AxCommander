using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AxCommander.Controls {
    public class AdvancedListViewItem : ListViewItem {
        private static string[] _humanReadableFileSizes = { "b", "Kb", "Mb", "Gb", "Tb" };

        private bool _selected = false;

        public FileSystemInfo FileSystemInfo { get; set; }
        public FileSystemType FileSystemType { get; set; }

        public bool IsSelected {
            get => _selected;
            set {
                if ( value != _selected ) {
                    _selected = value;

                    if ( _selected ) {
                        ForeColor = Color.Red;
                    }
                    else {
                        if ( ( FileSystemInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden )
                            ForeColor = Color.Gray;
                        else
                            ForeColor = Color.Black;
                    }
                }
            }
        }

        public string HumanReadableAttributes {
            get {
                if ( FileSystemInfo != null && FileSystemInfo.Exists ) {
                    return GetHumanReadableAttributes( FileSystemInfo.Attributes );
                }

                return string.Empty;
            }
        }

        public string HumanReadableSize {
            get {
                if ( FileSystemInfo != null && FileSystemInfo.Exists && FileSystemInfo is FileInfo fileInfo ) {
                    return GetHumanReadableSize( fileInfo.Length );
                }

                return string.Empty;
            }
        }

        public AdvancedListViewItem() : base() {}

        public AdvancedListViewItem( string text ) : base( text ) { }

        public AdvancedListViewItem( FileSystemInfo fileSystemInfo ) : base( fileSystemInfo.Name ) {
            FileSystemInfo = fileSystemInfo;

            if ( FileSystemInfo is DirectoryInfo ) {
                FileSystemType = FileSystemType.LocalDirectory;
            }
            if ( FileSystemInfo is FileInfo ) {
                FileSystemType = FileSystemType.LocalFile;
            }
        }

        public AdvancedListViewItem( FileInfo fileInfo ) : base( fileInfo.Name ) {
            //UseItemStyleForSubItems = false;

            FileSystemInfo = fileInfo;
            FileSystemType = FileSystemType.LocalFile;

            ListViewSubItem subItem = SubItems.Add( HumanReadableSize );
            //if (fileInfo.Length > 1024 * 1024 * 1024)
            //    BackColor = Color.LightCoral;

            SubItems.Add( fileInfo.LastAccessTime.ToString( "dd.MM.yyyy hh:mm" ) );
            SubItems.Add( HumanReadableAttributes );

            if ( ( fileInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden )
                ForeColor = Color.Gray;
        }

        public AdvancedListViewItem( DirectoryInfo directoryInfo ) : base( directoryInfo.Name ) {
            FileSystemInfo = directoryInfo;
            FileSystemType = FileSystemType.LocalDirectory;
            
            SubItems.Add( "<dir>" );
            SubItems.Add( directoryInfo.LastAccessTime.ToString( "dd.MM.yyyy hh:mm" ) );
            SubItems.Add( HumanReadableAttributes );

            if ( ( directoryInfo.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden )
                ForeColor = Color.Gray;
        }

        private static string GetHumanReadableAttributes( FileAttributes fileAttributes ) {
            string ret = string.Empty;

            if ( fileAttributes.HasFlag( FileAttributes.ReadOnly ) )
                ret += "r-";
            else
                ret += "rw";

            if ( fileAttributes.HasFlag( FileAttributes.System ) )
                ret += "s";
            else
                ret += "-";

            return ret;
        }

        public static string GetHumanReadableSize( long size ) {
            int order = 0;
            double innerSize = size;

            while ( innerSize >= 1024 && order < _humanReadableFileSizes.Length - 1 ) {
                order++;
                innerSize = innerSize / 1024;
            }

            return string.Format( "{0:0.##} {1}", innerSize, _humanReadableFileSizes[ order ] );
        }
    }
}
