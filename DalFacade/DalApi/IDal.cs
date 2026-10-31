
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        IStudent student { get; }
        IQuestion question { get; }
        IQuestionsstudent Questionsstudent { get; }
        ITest test { get; }
        IAnswer answer { get; }
    }
}
