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
        public List<CheckBox> CheckBoxes = new List<CheckBox>();
        public Quiz CurrentQuiz;
        public int MultiChoiseUserCorrectAnswers;
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
            if (CurrentQuiz.CurrentQuestion.Type == QuestionType.Choiсe)
            {
                for (int i = 0; i < userAnswers.Count; i++)
                {
                    if (userAnswers[i].Correct == true)
                    {
                        MessageBox.Show("valid");
                    }
                    else
                    {
                        MessageBox.Show("invalid");
                    }
                }
            }
            if (CurrentQuiz.CurrentQuestion.Type == QuestionType.MultiChoice)
            {
                MultiChoiseUserCorrectAnswers = 0;
                for (int i = 0; i < userAnswers.Count; i++)
                {
                    if (userAnswers[i].Correct)
                    {
                        MultiChoiseUserCorrectAnswers++;
                    }
                }
                if (MultiChoiseUserCorrectAnswers == userAnswers.Count && MultiChoiseUserCorrectAnswers == CurrentQuiz.CurrentQuestion.GetCorrectAnswersAmount())
                {
                    MessageBox.Show("valid");
                }
                else
                {
                    MessageBox.Show("invalid");
                }
            }
            if (CurrentQuiz.CurrentQuestion.Type == QuestionType.Open)
            {
                if(userAnswers[0].Text == CurrentQuiz.CurrentQuestion.Answers[0].Text)
                {
                    MessageBox.Show("valid");
                }
                else
                {
                    MessageBox.Show("invalid");
                }
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
                        userAnswers.Add(CurrentQuiz.CurrentQuestion.Answers[i]);
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
                    }
                }
            }
            if(CurrentQuiz.CurrentQuestion.Type == QuestionType.Open)
            {
                string openanswer = "";
                if (UserTextBox.Text.Split(' ').Length != 0)
                {
                    for (int i = 0; i < UserTextBox.Text.Split(' ').Length; i++)
                    {
                        openanswer += UserTextBox.Text.Split(' ')[i];
                    }
                }
                else
                {
                    openanswer = UserTextBox.Text;
                }
                Answer answer = new Answer(openanswer, true);
                userAnswers.Add(answer);
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

        private void button1_Click(object sender, EventArgs e)
        {
            CheckQuestion();
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
            if (CurrentQuiz != null)
            {
                CurrentQuiz.NextQuestion();
                ShowQuestion(CurrentQuiz.CurrentQuestion);
            }
        }
    }
}
