

using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace DalTest;

class Program
{
    private static readonly IDal s_dal = new Dal.DalList();

    private static void printMenue()
    {
        Console.WriteLine("Welcome to the DAL Test Program!");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. for Test");
        Console.WriteLine("2. for Student");
        Console.WriteLine("3. for Question");
        Console.WriteLine("4. for Answer");
        Console.WriteLine("5. for Questionsstudent");
        Console.WriteLine("6. for clean log");
        
        Console.WriteLine("0. Exit");
        int choice = int.Parse(Console.ReadLine()!);
        string selected = "";

        switch (choice)
        {
            case 1:
                selected = "Test";
                printSubMenue(selected, s_dal.Test);
                break;
            case 2:
                selected = "Student";
                printSubMenue(selected, s_dal.Student);
                break;
            case 3:
                selected = "Question";
                printSubMenue(selected, s_dal.Question);
                break;
            case 4:
                selected = "Answer";
                printSubMenue(selected, s_dal.Answer);
                break;
            case 5:
                selected = "Questionsstudent";
                printSubMenue(selected, s_dal.Questionsstudent);
                break;
            case 6:
                LogManager.ClearLog();
                Console.WriteLine("Log cleared successfully.");
                printMenue();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                printMenue();
                return;
        }
    }

    private static void printSubMenue<T>(string name, ICrud<T> crud)
    {
        Console.WriteLine($"You selected {name}. Please select an option:");
        Console.WriteLine($"1. Create {name}");
        Console.WriteLine($"2. Read {name}");
        Console.WriteLine($"3. ReadAll {name}");
        Console.WriteLine($"4. Update {name}");
        Console.WriteLine($"5. Delete {name}");
        Console.WriteLine($"6. for ReadDet");
        Console.WriteLine("0. Back to main menu");
        

        int choice = int.Parse(Console.ReadLine()!);

        switch (choice)
        {
            case 1:
                if (crud is ICrud<Test> testCrud)
                    create(testCrud, getTestDetails);
                else if (crud is ICrud<Student> studentCrud)
                    create(studentCrud, getStudentDetails);
                else if (crud is ICrud<Question> questionCrud)
                    create(questionCrud, getQuestionDetails);
                else if (crud is ICrud<Answer> answerCrud)
                    create(answerCrud, getAnswerDetails);
                else if (crud is ICrud<Questionsstudent> questionsstudentCrud)
                    create(questionsstudentCrud, getQuestionsstudentDetails);
                break;
            case 2:
                read(crud);
                break;
            case 3:
                readAll(crud);
                break;
            case 4:
                if (crud is ICrud<Test> testCrudForUpdate)
                    update(testCrudForUpdate, getTestDetails);
                else if (crud is ICrud<Student> studentCrudForUpdate)
                    update(studentCrudForUpdate, getStudentDetails);
                else if (crud is ICrud<Question> questionCrudForUpdate)
                    update(questionCrudForUpdate, getQuestionDetails);
                else if (crud is ICrud<Answer> answerCrudForUpdate)
                    update(answerCrudForUpdate, getAnswerDetails);
                else if (crud is ICrud<Questionsstudent> questionsstudentCrudForUpdate)
                    update(questionsstudentCrudForUpdate, getQuestionsstudentDetails);
                break;
            case 5:
                delete(crud);
                break;
                case 6:
                    readDet(crud);
                break;

            case 0:
                printMenue();
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                printSubMenue(name, crud);
                return;
        }
    }

    private static SubQuestions getSubjectFromUser()
    {
        Console.WriteLine("Available subjects:");
        foreach (SubQuestions subject in Enum.GetValues(typeof(SubQuestions)))
            Console.WriteLine($"  {(int)subject} - {subject}");

        Console.WriteLine("Enter subject number:");
        if (int.TryParse(Console.ReadLine(), out int subjectValue)
&& Enum.IsDefined(typeof(SubQuestions), subjectValue))
            return (SubQuestions)subjectValue;

        Console.WriteLine("Invalid subject. Using default: SQL");
        return SubQuestions.SQL;
    }

    private static void create<T>(ICrud<T> crud, Func<T> getDetails)
    {
        try
        {
            int id = crud.Create(getDetails());
            Console.WriteLine($"Item created successfully with ID: {id}");
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message);
        }
    }

    private static void update<T>(ICrud<T> crud, Func<T> getDetails)
    {
        try
        {
            crud.Update(getDetails());
            Console.WriteLine("Item updated successfully");
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message);

        }
    }

    private static Test getTestDetails()
    {
        Console.WriteLine("Enter Test Subject (enter a number for enum value):");
        SubQuestions subject = getSubjectFromUser();

        Console.WriteLine("Enter Test Date (format: yyyy-MM-dd):");
        DateTime.TryParse(Console.ReadLine(), out DateTime testDate);

        Console.WriteLine("Enter number of questions:");
        int.TryParse(Console.ReadLine(), out int sumQuestions);

        return new Test(subject, testDate, sumQuestions);
    }

    private static Student getStudentDetails()
    {
        Console.WriteLine("Enter Student ID:");
        int.TryParse(Console.ReadLine(), out int id);

        Console.WriteLine("Enter Student Name:");
        string? name = Console.ReadLine();

        Console.WriteLine("Enter Test ID:");
        int.TryParse(Console.ReadLine(), out int testId);

        Console.WriteLine("Enter Mark:");
        int.TryParse(Console.ReadLine(), out int mark);

        return new Student(id, name ?? "", testId, mark);
    }

    private static Question getQuestionDetails()
    {
        SubQuestions subject = getSubjectFromUser();

        Console.WriteLine("Enter Question Content:");
        string? content = Console.ReadLine();

        Console.WriteLine("Enter Right Answer ID:");
        int.TryParse(Console.ReadLine(), out int rightAnswerId);

        return new Question(subject, content ?? "", rightAnswerId);
    }

    private static Answer getAnswerDetails()
    {
        Console.WriteLine("Enter Question ID:");
        int.TryParse(Console.ReadLine(), out int questionId);

        Console.WriteLine("Enter Answer Content:");
        string? content = Console.ReadLine();

        return new Answer(questionId, content ?? "");
    }

    private static Questionsstudent getQuestionsstudentDetails()
    {
        Console.WriteLine("Enter Student ID:");
        int.TryParse(Console.ReadLine(), out int studentId);

        Console.WriteLine("Enter Test ID:");
        int.TryParse(Console.ReadLine(), out int testId);

        Console.WriteLine("Enter Question ID:");
        int.TryParse(Console.ReadLine(), out int questionId);

        Console.WriteLine("Enter Chosen Answer ID:");
        int.TryParse(Console.ReadLine(), out int answerId);

        return new Questionsstudent(studentId, testId, questionId, answerId);
    }

    private static void read<T>(ICrud<T> crud)
    {
        try
        {
            Console.WriteLine("Enter the ID of the item you want to read:");
            int id = int.Parse(Console.ReadLine()!);
            T? item = crud.Read(id);

            if (item != null)
                Console.WriteLine($"The chosen item: {item.ToString()}");
        }
        catch (Exception ex) {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message);
        }

    }

    private static void readAll<T>(ICrud<T> crud)
    {
        try
        {
            List<T> items = crud.ReadAll();
            if (items.Count > 0)
                Console.WriteLine($"The chosen items: {string.Join(", ", items.Select(x => x.ToString()))}");
        }
        catch (Exception ex) {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message);
        }
    }

    private static void delete<T>(ICrud<T> crud)
    {
        try
        {
            Console.WriteLine("Enter the ID of the item you want to delete:");
            int id = int.Parse(Console.ReadLine()!);
            crud.Delete(id);
            Console.WriteLine($"The item with ID {id} has been deleted");
        }
        catch (Exception ex) {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message);
        }
    }
    private static void readDet<T>(ICrud<T> crud)
    {
       
        try
        {

            if (crud is ICrud<Student> s)
            {
                ChooseStudentDetails(crud); }
            else if (crud is ICrud<Test> t)
            {
                ChooseTestDetails(crud);
            }
            else if(crud is ICrud<Question> q)
            {
                ChooseQuestionDetails(crud);
            }
            else if(crud is ICrud<Answer> a)
            {
                ChooseAnswerDetails(crud);
            }
            else if(crud is ICrud<Questionsstudent> qs)
            {
               ChooseQuestionsstudentDetails(crud);
            }
        }
           
        
        
    }

    private static void ChooseQuestionsstudentDetails<T>(ICrud<T> crud)
    {
        Console.WriteLine("Choose a filter for Questionsstudent:");
        Console.WriteLine("1. By Student ID");
        Console.WriteLine("2. By Test ID");
        Console.WriteLine("3. By Question ID");
        Console.WriteLine("4. By Answer ID");
        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the value for the chosen filter:");
        string value = Console.ReadLine();
        switch (choice) {
            case 1:
                int studentId = int.Parse(value);
                Questionsstudent qsByStudentId = crud.ReadDet(qs => qs.studentId == studentId);
                break;
            case 2:
                int testId = int.Parse(value);
                Questionsstudent qsByTestId = crud.ReadDet(qs => qs.testId == testId);
                break;
            case 3:
                int questionId = int.Parse(value);
                Questionsstudent qsByQuestionId = crud.ReadDet(qs => qs.questionId == questionId);
                break;
            case 4:
                int id = int.Parse(value);
                Questionsstudent questionsstudent = crud.ReadDet(qs => qs.questudentId == id);
                break;
        }
    }

    private static void ChooseAnswerDetails<T>(ICrud<T> crud)
    {
        Console.WriteLine("Choose a filter for Answer:");
        Console.WriteLine("1.By "
    }

    private static void ChooseQuestionDetails<T>(ICrud<T> crud)
    {
        throw new NotImplementedException();
    }

    private static void ChooseTestDetails<T>(ICrud<T> crud)
    {
        Console.WriteLine("Choose a filter for Tests:");
        Console.WriteLine("1. By Subject");
        Console.WriteLine("2. By Date");
        Console.WriteLine("3. By Number of Questions");
        Console.WriteLine("4. By ID");
        int choice = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the value for the chosen filter:");
        string value = Console.ReadLine();
        switch (choice)
        {
            case 1:
              Test test=  crud.ReadDet(t=> t.subjTest == value);
                break;
                case 2:
                DateTime date = DateTime.Parse(value);
                Test testByDate = crud.ReadDet(t => t.dateTest == date);
                break;
                case 3:
                int numQuestions = int.Parse(value);
                Test testByNumQuestions = crud.ReadDet(t => t.sumQuestions == numQuestions);
                break;
                case 4:
                int id = int.Parse(value);
                Test testById = crud.ReadDet(t => t.testId == id);
                break;

        }
    }
    
    private static void ChooseStudentDetails(ICrud<Student> crud)
    {
        Console.WriteLine("Choose a filter for Students:");
        Console.WriteLine("1. By Name");
        Console.WriteLine("2. By Test ID");
        Console.WriteLine("3. By Mark");
        Console.WriteLine("4. By ID");
        int choice = int.Parse(Console.ReadLine()); 
        Console.WriteLine("Enter the value for the chosen filter:");
        string value = Console.ReadLine();
        switch (choice)
        {
            case 1:
               Student student= crud.ReadDet( s => s.name==value);
                break;
            case 2:
                int testId = int.Parse(value);
                Student studentByTestId = crud.ReadDet(s => s.testId == testId);
                break;
                case 3:
                int mark = int.Parse(value);
                Student studentByMark = crud.ReadDet(s => s.mark == mark);
                break;
                case 4:
                int id = int.Parse(value);
                Student studentById = crud.ReadDet(s => s.Id == id);
                break;

        }

    }

   

    static void Main(string[] args)
    {
        Initialization.Initialize(s_dal);
        printMenue();
    }
}
