using System;
using System.Collections.Generic;

namespace SimpleQuizer
{
    public class Quiz
    {
        public List<Question> Questions;

        public Quiz()
        {
            Questions = new List<Question>();
        }

        #region DEBUG

        public static Quiz GetTestQuiz()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.Text = "Для чего используется инжектор?";
            q.Type = QuestionType.Choiсe;
            q.Answers.Add(new Answer( "Для фильтрации выхлопных газов", false) );
            q.Answers.Add(new Answer( "Для подачи топливной смеси в камеру сгорания", true) );
            q.Answers.Add(new Answer( "Для увеличения подоваемого воздуха в камеру сгорания", false));
            q.Answers.Add(new Answer( "Для повышения мощности двигателя", false));

            quiz.Questions.Add(q);

            return quiz;
        }
        #endregion
    }
}


