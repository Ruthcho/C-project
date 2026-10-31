using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Answer
{
    public int AnswerId;
    public int QuestionId;
    public string AnswerContent;

    public Answer(int Qid, string content) {
        this.QuestionId = Qid;
       this.AnswerContent = content;
    }

    public Answer() { }
}
