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

        public static Quiz GetTestQuiz()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.QuastionText = "Тестовый вопрос";
            q.Type = QuestionType.Choiсe;
            q.Answers.Add("Ответ 1");
            q.Answers.Add("Ответ 2");
            q.Answers.Add("Ответ 3");

            quiz.Questions.Add(q);

            return quiz;
        }
    }
}


