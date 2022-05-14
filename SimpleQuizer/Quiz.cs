using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleQuizer
{
    public class Quiz
    {
        public List<Question> Questions;
        public Question CurrentQuestion => Questions[CurrentQuestionIndex];
        public int CurrentQuestionIndex;
        public Quiz()
        {
            Questions = new List<Question>();
            CurrentQuestionIndex = 0;
        }
    
        public void NextQuestion()
        {
            if (CurrentQuestionIndex + 1 >= Questions.Count) return;

            CurrentQuestionIndex++;
            
        }
        public void PrevQuestion()
        {
            if (CurrentQuestionIndex - 1 >= 0) CurrentQuestionIndex -= 1;
        }

        public void Save(string path)
        {
            Serialize(path);
        }
        public void Load(string path)
        {
            Deserialize(path);
        }
        private void Serialize(string path)
        {
            Stream s = File.Open(path, FileMode.OpenOrCreate);
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(s, Questions);
            s.Close();
        }

        private void Deserialize(string path)
        {
            Stream s = File.Open(path, FileMode.Open);
            BinaryFormatter f = new BinaryFormatter();
            Questions = (List<Question>)f.Deserialize(s);
            s.Close();
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

            q = new Question();
            q.Number = 2;
            q.Text = "Что содержит класс?";
            q.Type = QuestionType.MultiChoice;
            q.Answers.Add(new Answer("методы", true));
            q.Answers.Add(new Answer("поля", true));
            q.Answers.Add(new Answer("переменные", false));
            q.Answers.Add(new Answer("конструктор", true));

            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 3;
            q.Text = "Что такое мел?";
            q.Type = QuestionType.Open;
            q.Answers.Add(new Answer("кальций", true));


            quiz.Questions.Add(q);

            return quiz;
        }

        public static Quiz GetTesticQuiz()
        {
            Quiz quiz = new Quiz();

            Question q = new Question();
            q.Number = 1;
            q.Text = "что такое имя массива?";
            q.Type = QuestionType.Choiсe;
            q.Answers.Add(new Answer("ссылка на первую ячейку массива", true));
            q.Answers.Add(new Answer("имя массива", false));
            q.Answers.Add(new Answer("тип массива", false));
            q.Answers.Add(new Answer("количество ячеек", false));

            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 2;
            q.Text = "Что содержит класс?";
            q.Type = QuestionType.MultiChoice;
            q.Answers.Add(new Answer("методы", true));
            q.Answers.Add(new Answer("поля", true));
            q.Answers.Add(new Answer("переменные", false));
            q.Answers.Add(new Answer("конструктор", true));

            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 3;
            q.Text = "for(int i = 0; i < 5; i++)ConsoleWrite(i.Tostring()); что выведется?";
            q.Type = QuestionType.Open;
            q.Answers.Add(new Answer("01234", true));

            quiz.Questions.Add(q);

            q = new Question();
            q.Number = 4;
            q.Text = "как можно назвать класс Dog?  public class Dog : Animals";
            q.Type = QuestionType.Open;
            q.Answers.Add(new Answer("дочерний", true));

            quiz.Questions.Add(q);

            return quiz;
        }
        #endregion
    }
}


