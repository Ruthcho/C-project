using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public record Question
{
  public  int IdQuestion;
    public Enum? SubQuestion;
    public string QuestionContent;
    public int IsRightId;

    public Question(Enum subj, string content, int isRight) {
        this.SubQuestion = subj;
        this.QuestionContent = content;
        this.IsRightId = isRight;
    }

    public Question()
    {

    }
}
