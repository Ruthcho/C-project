

  using DalApi;
       using DO;
     
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
        catch (Exception ex) { }
        
       }

        private static void readAll<T>(ICrud<T> crud)
      {
        try
        {
            List<T> items = crud.ReadAll();
            if (items.Count > 0)
                Console.WriteLine($"The chosen items: {string.Join(", ", items.Select(x => x.ToString()))}");
        }
             catch (Exception ex) { }
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
        catch (Exception ex) { }
         }

        static void Main(string[] args)
         {
              Initialization.Initialize(s_dal);
             printMenue();
          }
  }
