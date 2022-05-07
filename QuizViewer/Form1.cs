using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleQuizer;

namespace SimpleQuizer.Viewer
{
    public partial class Form1 : Form
    {
        public List<RadioButton> RadioButtons = new List<RadioButton>();
        public Question CurrentQuestion = new Question();
        public Form1()
        {
            InitializeComponent();
        }


        

        private void открытьТестовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz q = Quiz.GetTestQuiz();
            ShowQuestion(q.Questions[0]);
            CurrentQuestion = q.Questions[0];
        }


        private void ShowQuestion(Question question)
        {
            questionText.Text = question.Text;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            int answerCount = question.Answers.Count;
            
            tableLayoutPanel1.RowCount = answerCount;

            for(int i = 0; i < answerCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add( new RowStyle(SizeType.Percent, 100 / answerCount) );
            }

            for(int i = 0; i < answerCount; i++)
            {
              TableLayoutTextBoxCell textbox = new TableLayoutTextBoxCell(question.Answers[i], tableLayoutPanel1.GetRowHeights()[0], tableLayoutPanel1.GetColumnWidths()[1]);
              tableLayoutPanel1.Controls.Add(textbox, 1, i);
            }
         

            for (int i = 0; i < answerCount; i++)
            {
                RadioButtons.Clear();
                RadioButton r = new RadioButton();
                RadioButtons.Add(r);
                r.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
                r.Height = tableLayoutPanel1.GetRowHeights()[0]; 
                r.Width = tableLayoutPanel1.GetColumnWidths()[1]; 
                r.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                tableLayoutPanel1.Controls.Add(r, 0, i);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int answerCount = CurrentQuestion.Answers.Count;
            for (int i = 0; i < answerCount; i++)
            {
                if(RadioButtons[i].Checked == true && CurrentQuestion.Answers[i].Correct)
                {
                    MessageBox.Show("правильно");
                }
                else
                {
                    MessageBox.Show("не правильно");
                }
            }
        }
    }
}
