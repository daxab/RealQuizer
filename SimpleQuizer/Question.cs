using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    public enum QuestionType
    {
        Choiсe,
        MultiChoice
    }

    public class Question
    {
        public int Number;
        public string Text;
        public QuestionType Type;
        public List<Answer> Answers;
  
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
