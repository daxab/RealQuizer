using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleQuizer
{
    public enum QuestionType
    {
        Choiсe,
        MultiChoice,
        Open
    }
    
    [Serializable]
    public class Question
    {
        public int Number;
        public string Text;
        public QuestionType Type;
        public List<Answer> Answers;
        public List<Answer> UserAnswers;
  
        public Question()
        {
            Answers = new List<Answer>();
            UserAnswers = new List<Answer>();
        }
        public int GetCorrectAnswersAmount()
        {
            int CorrectAnswersAmount = 0;
            for (int i = 0; i < this.Answers.Count; i++)
            {
                if (this.Answers[i].Correct)
                {
                    CorrectAnswersAmount++;
                }
            }
            return CorrectAnswersAmount;
        }
    }
}
