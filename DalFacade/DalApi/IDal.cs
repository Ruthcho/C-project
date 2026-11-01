
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        IStudent Student { get; }
        IQuestion Question { get; }
        IQuestionsstudent Questionsstudent { get; }
        ITest Test { get; }
        IAnswer Answer { get; }
    }
}
