using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleQuizer.Viewer
{
    public class TableTextBox : TextBox
    {
        public TableTextBox()
        {
            this.Location = new Point(15, 214);
            this.Size = new Size(859,297); 
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Multiline = true;

        }
    }
}
