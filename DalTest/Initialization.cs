using DO;
using DalApi;
namespace DalTest;


public static class Initialization
{
    private static IDal s_dal;
    private static void createTest()
    {
      Test t1 = new Test(SubQuestions.SQL,new DateTime(2026,10,06), 25);
        Test t2 = new Test(SubQuestions.java,new DateTime(2026,10,07), 30);
        Test t3 = new Test(SubQuestions.cs,new DateTime(2026,10,08), 35);
        Test t4 = new Test(SubQuestions.c,new DateTime(2026,10,09), 40);
        Test t5 = new Test(SubQuestions.python,new DateTime(2026,10,10), 45);
        s_dal.Test.Create(t1);
        s_dal.Test.Create(t2);
        s_dal.Test.Create(t3);
        s_dal.Test.Create(t4);
        s_dal.Test.Create(t5);

    }
    private static void createStudent()
    {
        Student s1 = new Student(217897122, "rut", 100, 0);
        Student s2 = new Student(645342573, "mimi", 120, 0);
        Student s3 = new Student(210987654, "david", 130, 0);
        Student s4 = new Student(321098765, "shira", 140, 0);
        Student s5 = new Student(432109876, "shira", 150, 0);
        Student s6 = new Student(543210987, "ayala", 160, 0);
        s_dal.student.Create (s1);
        s_dal.student.Create (s2);
        s_dal.student.Create (s3);
        s_dal.student.Create (s4);
        s_dal.student.Create (s5);
        s_dal.student.Create (s6);
    }

    private static void createQuestion()
    {
        Question q1 = new Question(SubQuestions.SQL, "What is SQL?", 4);
        Question q2 = new Question(SubQuestions.java, "What is Java?", 5);
        Question q3 = new Question(SubQuestions.cs, "What is C#?", 9);
        Question q4 = new Question(SubQuestions.c, "What is C?", 12);
        Question q5 = new Question(SubQuestions.python, "What is Python?", 15);
        s_dal.question.Create(q1);
        s_dal.question.Create(q2);
        s_dal.question.Create(q3);
        s_dal.question.Create(q4);
        s_dal.question.Create(q5);
    }

    private static void createAnswer()
    {
        Answer a1 = new Answer(1,"Structured Query Language");
        Answer a11 = new Answer(1,"SQL is a programming language");
        Answer a12 = new Answer(1,"SQL is used to manage data in relational databases");
        Answer a13 = new Answer(1,"SQL is used to retrieve and manipulate data in databases");
        Answer a2 = new Answer(5,"Java Programming Language");
        Answer a21 = new Answer(5,"Java is a high-level programming language");
        Answer a22 = new Answer(5,"Java is used to develop applications for the web, mobile, and desktop");
        Answer a23 = new Answer(5,"Java is an object-oriented programming language");
        Answer a3 = new Answer(9,"C# Programming Language");
        Answer a31 = new Answer(9,"C# is a modern, object-oriented programming language");
        Answer a32 = new Answer(9,"C# is used to develop applications for Windows, web, and mobile");
        Answer a33 = new Answer(9,"C# is part of the .NET framework");
        Answer a4 = new Answer(9,"C# Programming Language");
        Answer a41 = new Answer(9,"C# is a modern, object-oriented programming language");
        Answer a42 = new Answer(9,"C# is used to develop applications for Windows, web, and mobile");
        Answer a43 = new Answer(9,"C# is part of the .NET framework");
        Answer a5 = new Answer(13,"C Programming Language");
        Answer a51 = new Answer(13,"C is a general-purpose programming language");
Answer a52 = new Answer(13,"C is used to develop operating systems, compilers, and embedded systems");
        Answer a53 = new Answer(13,"C is a procedural programming language");
        Answer a6 = new Answer(17,"Python Programming Language");
        Answer a61 = new Answer(17,"Python is a high-level, interpreted programming language");
        Answer a62 = new Answer(17,"Python is used for web development, data analysis, artificial intelligence, and more");
        Answer a63 = new Answer(17,"Python has a simple syntax and is easy to learn");
        s_dal.answer.Create(a1);
        s_dal.answer.Create(a11);
        s_dal.answer.Create(a12);
        s_dal.answer.Create(a13);
        s_dal.answer.Create(a2);
        s_dal.answer.Create(a21);
        s_dal.answer.Create(a22);
        s_dal.answer.Create(a23);
        s_dal.answer.Create(a3);
        s_dal.answer.Create(a31);
        s_dal.answer.Create(a32);
        s_dal.answer.Create(a33);
        s_dal.answer.Create(a4);
        s_dal.answer.Create(a41);
        s_dal.answer.Create(a42);
        s_dal.answer.Create(a43);
        s_dal.answer.Create(a5);
        s_dal.answer.Create(a51);
        s_dal.answer.Create(a52);
        s_dal.answer.Create(a53);
        s_dal.answer.Create(a6);
        s_dal.answer.Create(a61);
        s_dal.answer.Create(a62);
        s_dal.answer.Create(a63);

    }

    private static void createQuestionsstudent()
    {
        Questionsstudent qs1 = new Questionsstudent(543210987, 100, 1, 2);
        Questionsstudent qs2 = new Questionsstudent(432109876, 110, 5, 7);
        Questionsstudent qs3 = new Questionsstudent(321098765, 120, 9, 12);
        Questionsstudent qs4 = new Questionsstudent(210987654, 130, 13, 17);
        Questionsstudent qs5 = new Questionsstudent(645342573, 140, 17, 22);
        s_dal.Questionsstudent.Create(qs1);
        s_dal.Questionsstudent.Create(qs2);
        s_dal.Questionsstudent.Create(qs3);
        s_dal.Questionsstudent.Create(qs4);
        s_dal.Questionsstudent.Create(qs5);
    }

    public static void Initialize(IDal dal)
    {
        s_dal = dal;
        createStudent();
        createTest();
        createQuestion();
        createAnswer();
        createQuestionsstudent();

    }
}
