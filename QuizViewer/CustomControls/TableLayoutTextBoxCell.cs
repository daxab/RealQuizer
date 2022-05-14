using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleQuizer.Viewer
{
    public class TableLayoutTextBoxCell : TextBox
    {

        public TableLayoutTextBoxCell(Answer answer, int cellHeight, int cellWIdth)
        {
            this.Multiline = true;
            this.ReadOnly = true;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Height = cellHeight;
            this.Width = cellWIdth;
            this.Text = answer.Text + answer.Correct;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
