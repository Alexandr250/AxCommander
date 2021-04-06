using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AxCommander.Controls
{
    public class RootsComboBox : ComboBox
    {
        public RootsComboBox()
        {
            ReloadRoots();
        }

        public void ReloadRoots()
        {
            //Items.Clear();
            List<RootComboBoxItem> dataSource = new List<RootComboBoxItem>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                RootComboBoxItem item = new RootComboBoxItem( new AxDriveInfo( drive) );
                dataSource.Add(item);
            }

            DataSource = dataSource;
            DisplayMember = "DisplayMember";
            ValueMember = "DisplayMember";

            if (Items.Count != 0)
                base.SelectedIndex = 0;
        }

        public string SelectedRoot
        {
            get
            {
                return (SelectedItem as RootComboBoxItem).Root.FullName;
            }
        }
    }

    [Serializable]
    public class RootComboBoxItem
    {
        public RootComboBoxItem( FileSystemInfo info )
        {
            Root = info;
        }

        public FileSystemInfo Root { get; private set; }

        public override string ToString()
        {
            if (Root.Exists)
                return Root.Name;

            return string.Empty;
        }

        public string DisplayMember => Root.Name;
    }

    public class AxDriveInfo : FileSystemInfo
    {
        private DriveInfo _driveInfo;

        public AxDriveInfo(DriveInfo driveInfo)
        {
            _driveInfo = driveInfo;
        }
        public override string Name => _driveInfo.Name;

        public override bool Exists => true;

        public override void Delete()
        {
            return;
        }
    }
}
