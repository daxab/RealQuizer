using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SimpleQuizer.Viewer
{
    public partial class QuizResultForm : Form
    {
        public QuizResult quizresult;

         public QuizResultForm(QuizResult result)
        {
            quizresult = result;
            InitializeComponent();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();


            init();

            /*
            MessageBox.Show(tableLayoutPanel1.RowCount.ToString());
            MessageBox.Show(quizresult.quiz.Questions.Count.ToString());


            for (int i = 0; i < quizresult.quiz.Questions.Count; i++)
            {
               TableLayoutTextBoxCell textbox = new TableLayoutTextBoxCell(quizresult.quiz.Questions[i].UserAnswers[0], tableLayoutPanel1.GetRowHeights()[0], tableLayoutPanel1.GetColumnWidths()[1]);
               tableLayoutPanel1.Controls.Add(textbox, 1, i);
            }*/


        }

        public void init()
        {
            for (int i = 0; i < 5; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / 5));
            }
        }
    }
}
