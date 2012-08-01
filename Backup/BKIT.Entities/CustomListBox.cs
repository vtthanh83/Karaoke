using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BKIT.Entities
{
    #region CustomListBox
    public class CustomListBox : ListBox
    {
        public CustomListBox()
        {
            // Set owner draw mode
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 55;
            //this.DrawMode = DrawMode.OwnerDrawVariable;
            //this.DrawMode = DrawMode.Normal;
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle(); //ListBox lb1 = new ListBox(); lb1.DrawMode = DrawMode.

            CustomListBoxItem item;
            Rectangle bounds = e.Bounds;
            Size imageSize = new Size(0, 0);
            Image ImageAvatar;

            try
            {
                item = (CustomListBoxItem)Items[e.Index];
                if (item.strAvatar != "")
                {
                    // Draw Image
                    ImageAvatar = ImageFromStr(item.strAvatar);
                    e.Graphics.DrawImage(ImageAvatar,
                        bounds.Left, bounds.Top, bounds.Height, bounds.Height);
                }
                // Draw Name
                e.Graphics.DrawString(item.Name,
                    new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold,
                        System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                    , new SolidBrush(e.ForeColor),
                    bounds.Left + bounds.Height, bounds.Top);

                // Draw Username
                e.Graphics.DrawString(item.Username,
                    new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic,
                        System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                    , new SolidBrush(e.ForeColor),
                    bounds.Left + bounds.Height, bounds.Top + 17);

                // Draw UserGroupName
                e.Graphics.DrawString(item.UserGroupName,
                    new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic,
                        System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                    , new SolidBrush(e.ForeColor),
                    bounds.Left + bounds.Height, bounds.Bottom - 20);
            }
            catch
            {
            }
            base.OnDrawItem(e);
        }
        public static Image ImageFromStr(string strImageData)
        {
            if (strImageData == "")
                return null;
            byte[] byteImageData = new Byte[0];
            byteImageData = Convert.FromBase64String(strImageData);
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(byteImageData);
            return img;
        }

    }
    #endregion

    #region CustomListBoxItem
    public class CustomListBoxItem
    {
        private string _strAvatar;
        public string strAvatar
        {
            get { return _strAvatar; }
            set { _strAvatar = value; }
        }


        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Username;
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private string _UserGroupName;
        public string UserGroupName
        {
            get { return _UserGroupName; }
            set { _UserGroupName = value; }
        }
        //constructor

        public CustomListBoxItem()
        {
            this._strAvatar = "";
            this._Name = "";
            this._Username = "";
            this._UserGroupName = "";
        }

        public CustomListBoxItem(string Name, string Username, string UserGroupName, string strAvatar)
        {
            this._strAvatar = strAvatar;
            this._Name = Name;
            this._Username = Username;
            this._UserGroupName = UserGroupName;
        }
        public CustomListBoxItem(string Name, string Username, string UserGroupName) :
            this(Name, Username, UserGroupName, "") { }

        public override string ToString()
        {
            if (String.Compare(this._Name, this._Username) > 0)
                return this._Name;
            return this._Username;
        }
    }
    #endregion
}