using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public List<CheckBox> CheckBoxes = new List<CheckBox>();
        public Quiz CurrentQuiz;
        public int UserCorrectAnswers;
        public int CorrectQuestions = 0;
        public TableTextBox UserTextBox = new TableTextBox();
        //public List<RadioButton> RadioButtons = new List<RadioButton>();
        private List<Answer> userAnswers = new List<Answer>();
        public Form1()
        {
            InitializeComponent();
        }


        

        private void открытьТестовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quiz q = Quiz.GetTestQuiz();
            CurrentQuiz = q;
            ShowQuestion(q.Questions[0]);
        }

        private void CheckQuestion()
        {
            GetUserInput();
            CheckUserAnswers();
        }

        private void CheckUserAnswers()
        {
            
            UserCorrectAnswers = 0;
            for (int i = 0; i < userAnswers.Count; i++)
            {
                if (userAnswers[i].Correct)
                {
                    UserCorrectAnswers++;
                }
            }
            if (UserCorrectAnswers == CurrentQuiz.CurrentQuestion.GetCorrectAnswersAmount() && UserCorrectAnswers == userAnswers.Count)
            {
                CorrectQuestions++;
            }
        }

        private void GetUserInput()
        {
            userAnswers.Clear();
            int answerCount = CurrentQuiz.CurrentQuestion.Answers.Count;
            if (CurrentQuiz.CurrentQuestion.Type == QuestionType.Choiсe)
            {
                for (int i = 0; i < answerCount; i++)
                {
                    if (RadioButtons[i].Checked == true)
                    {
                        CurrentQuiz.CurrentQuestion.UserAnswers.Add(CurrentQuiz.CurrentQuestion.Answers[i]);
                    }
                 
                }
            }
            if (CurrentQuiz.CurrentQuestion.Type == QuestionType.MultiChoice)
            {
                for (int i = 0; i < answerCount; i++)
                {
                    if (CheckBoxes[i].Checked == true)
                    {
                        userAnswers.Add(CurrentQuiz.CurrentQuestion.Answers[i]);
                        CurrentQuiz.CurrentQuestion.UserAnswers.Add(CurrentQuiz.CurrentQuestion.Answers[i]);
                    }
                }
            }
            if(CurrentQuiz.CurrentQuestion.Type == QuestionType.Open)
            {
                for(int i = 0; i < CurrentQuiz.CurrentQuestion.Answers.Count; i++)
                {
                    if (UserTextBox.Text.Trim().ToLower() == CurrentQuiz.CurrentQuestion.Answers[0].Text)
                    {
                        userAnswers.Add(new Answer(UserTextBox.Text, true));
                        CurrentQuiz.CurrentQuestion.UserAnswers.Add(new Answer(UserTextBox.Text, true));
                    }
                    else
                    {
                        userAnswers.Add(new Answer(UserTextBox.Text, false));
                        CurrentQuiz.CurrentQuestion.UserAnswers.Add(new Answer(UserTextBox.Text, false));
                    }
                }
            }
        }

        private void ShowQuestion(Question question)
        {
            RadioButtons.Clear();
            CheckBoxes.Clear();
            questionText.Text = question.Text;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            int answerCount = question.Answers.Count;
            
            tableLayoutPanel1.RowCount = answerCount;

            if(CurrentQuiz.CurrentQuestion.Type == QuestionType.Choiсe || CurrentQuiz.CurrentQuestion.Type == QuestionType.MultiChoice)
            {
                for (int i = 0; i < answerCount; i++)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / answerCount));
                }

                for (int i = 0; i < answerCount; i++)
                {
                    TableLayoutTextBoxCell textbox = new TableLayoutTextBoxCell(question.Answers[i], tableLayoutPanel1.GetRowHeights()[0], tableLayoutPanel1.GetColumnWidths()[1]);
                    tableLayoutPanel1.Controls.Add(textbox, 1, i);
                }
            }
         
            for (int i = 0; i < answerCount; i++)
            {
 
                if(CurrentQuiz.CurrentQuestion.Type == QuestionType.Choiсe)
                {
                    tableLayoutPanel1.Visible = true;
                    TableRadioButton r = new TableRadioButton(tableLayoutPanel1.GetRowHeights()[0], tableLayoutPanel1.GetColumnWidths()[1]);
                    RadioButtons.Add(r);
                    tableLayoutPanel1.Controls.Add(r, 0, i);
                }
                if (CurrentQuiz.CurrentQuestion.Type == QuestionType.MultiChoice)
                {
                    tableLayoutPanel1.Visible = true;
                    TableCheckBox r = new TableCheckBox(tableLayoutPanel1.GetRowHeights()[0], tableLayoutPanel1.GetColumnWidths()[1]);
                    CheckBoxes.Add(r);
                    tableLayoutPanel1.Controls.Add(r, 0, i);
                }
                if(CurrentQuiz.CurrentQuestion.Type == QuestionType.Open)
                {
                    tableLayoutPanel1.Visible = false;
                    this.Controls.Add(UserTextBox);
                }
            }
        }

        private void TryShowResultForm()
        {
            if(CurrentQuiz.CurrentQuestionIndex+1 == CurrentQuiz.Questions.Count)
            {
               
                QuizResultForm f = new QuizResultForm(new QuizResult(CurrentQuiz));
                f.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CurrentQuiz.CurrentQuestionIndex+1 == CurrentQuiz.Questions.Count)
            {
                DialogResult result = MessageBox.Show("Правильных ответов:"+(CorrectQuestions.ToString()) + "/" + CurrentQuiz.Questions.Count.ToString(), "опа", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    TryShowResultForm();
                }
            }
            CheckQuestion();
            if (CurrentQuiz != null)
            {
                CurrentQuiz.NextQuestion();
                ShowQuestion(CurrentQuiz.CurrentQuestion);
            }
        
        }

        private void PrevQusetion_Click(object sender, EventArgs e)
        {
            if (CurrentQuiz != null)
            {
                CurrentQuiz.PrevQuestion();
                ShowQuestion(CurrentQuiz.CurrentQuestion);
            }
        }

        private void NextQuestion_Click(object sender, EventArgs e)
        {
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Quiz.GetTesticQuiz().Save("TesticQuiz.tqz");
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.tqz | *.tqz";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentQuiz = new Quiz();
                CurrentQuiz.Load(openFileDialog1.FileName);
            }
            ShowQuestion(CurrentQuiz.Questions[0]);
        }
    }
}
