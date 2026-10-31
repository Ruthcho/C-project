using DO;
using System;

namespace DalList;

internal static class DataSource
{
    public static List<Answer>? answers = new List<Answer>();
    public static List<Questionsstudent>? questionsstudents = new List<Questionsstudent>();
    public static List<Question>? questions = new List<Question>();
    public static List<Test>? tests = new List<Test>();
    public static List<Student>? students = new List<Student>();

    internal static class Config
    {
        internal const int answerNum = 1;
        private static int ansId = answerNum;
        public static int AnsId { get => ansId += 1; }

        internal const int questionNum = 1;
        private static int quesId = questionNum;
        public static int QuesId { get => quesId += 4; }

        internal const int testNum = 100;
        private static int testId = testNum;
        public static int TestId { get => testId += 10; }


        internal const int quesstudent = 100;
        private static int qsId = quesstudent;
        public static int QsId { get => qsId += 10; }
    }
}









