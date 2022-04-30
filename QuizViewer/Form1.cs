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


        #region DEBUG
        private void открытьТестовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz q = Quiz.GetTestQuiz();

            ShowQuestion(q.Questions[0]);
        }

        #endregion

        private void CheckQuestion()
        {
            
        }

        private void ShowQuestion(Question question)
        {
            questionNumberLable.Text = "Вопрос" + question.Number.ToString();
            questionText.Text =  question.Text;

            if (question.Type == QuestionType.Choiсe)
            {
                questionInfoLable.Text = "Выберете правильный ответ.";
            }

            // Верстка таблицы
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            int answerCount = question.Answers.Count;

            tableLayoutPanel1.RowCount = answerCount;

            for(int i = 0; i < answerCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add( new RowStyle(SizeType.Percent, 100 / answerCount) );
            }

            // Добавление ответов
            for (int i = 0; i < answerCount; i++)
            {
                
                TextBox t = new TextBox();
                t.Multiline = true;
                t.Height = tableLayoutPanel1.GetRowHeights()[0]; // 0 строчка
                t.Width = tableLayoutPanel1.GetColumnWidths()[1]; // 1 столбец
                t.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
                t.Multiline = true;
                t.ReadOnly = true;
                t.Text = question.Answers[i].Text + question.Answers[i].Correct.ToString();
                t.BackColor = System.Drawing.SystemColors.Window;
                t.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                t.Location = new System.Drawing.Point(52, 5);

                tableLayoutPanel1.Controls.Add(t, 1, i);
            }
            
            // Добавление контролов
            for (int i = 0; i < answerCount; i++)
            {
                RadioButton r = new RadioButton();
                r.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
                r.Height = tableLayoutPanel1.GetRowHeights()[0]; // 0 строчка
                r.Width = tableLayoutPanel1.GetColumnWidths()[1]; // 1 столбец
                r.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));

                tableLayoutPanel1.Controls.Add(r, 0, i);
            }

      
        }
    }
}
