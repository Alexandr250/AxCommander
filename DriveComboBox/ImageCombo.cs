/*
 * ImageCombo Control is developed by Niels Penneman
 * All credit goes to him for this control
 * http://www.codeproject.com/cs/combobox/ImageCombo_NET.asp
 * 
*/
namespace ZinoLib.Windows.Controls
{
    using System.Drawing;
    using System.Windows.Forms;


    public class ImageCombo : ComboBox
	{
		// constructor
		public ImageCombo() => DrawMode = DrawMode.OwnerDrawFixed; // set draw mode to owner draw
 
        // ImageList property
        public ImageList ImageList { get; set; } = new ImageList();

        // customized drawing process
        protected override void OnDrawItem(DrawItemEventArgs e)
		{
			// draw background & focus rect
			e.DrawBackground();
			e.DrawFocusRectangle();

			// check if it is an item from the Items collection
			if (e.Index < 0)
				// not an item, draw the text (indented)
				e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
			else
			{
				// check if item is an ImageComboItem
				if (Items[e.Index].GetType() == typeof(ImageComboItem))
				{
					// get item to draw
					ImageComboItem item = (ImageComboItem)Items[e.Index];

					// get forecolor & font
					Color forecolor = (item.ForeColor != Color.FromKnownColor(KnownColor.Transparent)) ? item.ForeColor : e.ForeColor;
					Font font = item.Mark ? new Font(e.Font, FontStyle.Bold) : e.Font;

					// -1: no image
					if (item.ImageIndex != -1 && item.ImageIndex < ImageList.Images.Count )
					{
						// draw image, then draw text next to it
						ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);
						e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
					}
					else
						// draw text (indented)
						e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
				}
				else
					// it is not an ImageComboItem, draw it
					e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
			}

			base.OnDrawItem(e);
		}

	}

	public class ImageComboItem
	{
        // constructors
        public ImageComboItem()
		{
		}

        public ImageComboItem(string Text) => this.Text = Text;

        public ImageComboItem(string Text, int ImageIndex)
		{
			this.Text = Text;
			this.ImageIndex = ImageIndex;
		}

		public ImageComboItem(string Text, int ImageIndex, bool Mark)
		{
			this.Text = Text;
			this.ImageIndex = ImageIndex;
			this.Mark = Mark;
		}

		public ImageComboItem(string Text, int ImageIndex, bool Mark, Color ForeColor)
		{
			this.Text = Text;
			this.ImageIndex = ImageIndex;
			this.Mark = Mark;
			this.ForeColor = ForeColor;
		}

		public ImageComboItem(string Text, int ImageIndex, bool Mark, Color ForeColor, object Tag)
		{
			this.Text = Text;
			this.ImageIndex = ImageIndex;
			this.Mark = Mark;
			this.ForeColor = ForeColor;
			this.Tag = Tag;
		}

        // Item value
        public string ItemValue { get; set; } = null;

        // forecolor
        public Color ForeColor { get; set; } = Color.FromKnownColor(KnownColor.Transparent);

        // image index
        public int ImageIndex { get; set; } = -1;

        // mark (bold)
        public bool Mark { get; set; } = false;

        // tag
        public object Tag { get; set; } = null;

        // item text
        public string Text { get; set; } = null;

        // ToString() should return item text
        public override string ToString() => Text;
    }
}