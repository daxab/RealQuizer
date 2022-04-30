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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quiz q = Quiz.GetTestQuiz();
            ShowQuestion(q.Questions[0]);
        }

        private void ShowQuestion(Question question)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < question.Answers.Count; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / question.Answers.Count));

                tableLayoutPanel1.Controls.Add(new Label() { Text = question.Answers[i] }, 1, i);
            }
            
        }
    }
}
