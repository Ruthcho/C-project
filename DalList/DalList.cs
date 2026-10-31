using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

public class DalList:IDal
{
    public IStudent Student => new StudentImplementation();
    
    public ITest Test => new TestImplementation();
    public IQuestion Question => new QuestionImplementation();
    public IQuestionsstudent Questionsstudent => new QuestiosstudentImplementation();
    public IAnswer Answer => new AnswerImplementation();
}
