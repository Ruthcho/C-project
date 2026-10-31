using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Test //ישות מבחן
{
    public int TestId; //מזהה מבחן
    public Enum SubjTest; //נושא המבחן
    public DateTime TestDate; //תאריך המבחן
    public int SumQuestions; //מספר השאלות

    public Test( Enum subj, DateTime date, int sumq)
    {
        this.SubjTest = subj;
        this.TestDate = date;
        this.SumQuestions = sumq;
    }

    public Test()
    {

    }
}
