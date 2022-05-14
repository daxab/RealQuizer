using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleQuizer.Viewer
{
    class TableCheckBox : CheckBox
    { 
        public TableCheckBox(int cellHeight, int cellWIdth)
        {
            this.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Height = cellHeight;
            this.Width = cellWIdth;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
    }
}
