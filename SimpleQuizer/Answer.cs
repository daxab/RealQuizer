using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizer
{
    [Serializable]
    public class Answer
    {
        public string Text;
        public bool Correct;

        public Answer(string text, bool correct)
        {
            Text = text;
            Correct = correct;
        }
    }
}
