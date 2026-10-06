using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Answer
{
    int AnswerId;
    int QuestionId;
    string AnswerContent;

    public Answer(int Aid, int Qid, string content) {
       this.AnswerId = Aid;
        this.QuestionId = Qid;
       this.AnswerContent = content;
    }

    public Answer() { }
}
