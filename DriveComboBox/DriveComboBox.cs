namespace ZinoLib.Windows.Controls
{
    using global::DriveComboBox.Properties;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;

    public class DriveComboBox : ImageCombo
	{
		public DriveComboBox() : base()
		{
            ImageList.ColorDepth = ColorDepth.Depth32Bit;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

			ImageList.Images.Add(Resources.harddisk);
			ImageList.Images.Add(Resources.cdrom);
			ImageList.Images.Add(Resources.floppy);

			BuildDriveList();
		}


        public string SelectedDrive => base.SelectedIndex != -1 ? (SelectedItem as ImageComboItem).ItemValue : null;

        public void BuildDriveList()
		{
			base.Items.Clear();

            foreach( DriveInfo drive in DriveInfo.GetDrives() )
			{
				int imageIndex = 0;

				if (drive.DriveType == DriveType.CDRom)
				{
					imageIndex = 1;
				}
				else if (drive.DriveType == DriveType.Removable)
				{
					imageIndex = 2;
				}

				ImageComboItem item = new ImageComboItem($"{drive.Name} ({drive.DriveType})", imageIndex, false);
				item.ItemValue = drive.Name;
				base.Items.Add(item);
			}

			if( base.Items.Count!=0 )
				base.SelectedIndex = 0;
		}

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ObjectCollection Items => base.Items;
    }
}
