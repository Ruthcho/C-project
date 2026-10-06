using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Question
{
    int IdQuestion;
    Enum SubQuestion;
    string QuestionContent;
    int IsRightId;

    public Question(int id, Enum subj, string content, int isRight) { 
        this.IdQuestion = id;
        this.SubQuestion = subj;
        this.QuestionContent = content;
        this.IsRightId = isRight;
    }

    public Question()
    {

    }
}
