using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Test //ישות מבחן
{
    int TestId; //מזהה מבחן
    Enum SubjTest; //נושא המבחן
    DateTime TestDate; //תאריך המבחן
    int SumQuestions; //מספר השאלות

    public Test(int id, Enum subj, DateTime date, int sumq)
    {
        this.TestId = id;
        this.SubjTest = subj;
        this.TestDate = date;
        this.SumQuestions = sumq;
    }

    public Test()
    {

    }
}
