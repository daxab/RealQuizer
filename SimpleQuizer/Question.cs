using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    public enum QuestionType
    {
        Choiсe,
        Open
    }

    public class Question
    {
        public int Number;
        public string QuastionText;
        public QuestionType Type;
        public List<string> Answers;
    }
}
