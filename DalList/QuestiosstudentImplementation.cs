using DO;   
using DalApi;
using DalList;
using System.Data;

namespace Dal;

internal class QuestiosstudentImplementation : IQuestionsstudent
{
    public int Create(Questionsstudent item)
    {
        item.QuestudentId= DataSource.Config.QsId;
        DataSource.questionsstudents.Add(item);
            return item.QuestudentId;
    }

    public void Delete(int idQ)
    {
foreach (Questionsstudent item in DataSource.questionsstudents)
        {
            if(item.QuestudentId==idQ)
            {
                DataSource.questionsstudents.Remove(item);
                return;
            }
        }
        throw new NotFoundIdException($"QuestionStudent with id {idQ} not found.");

    }

    public Questionsstudent? Read(int idQ)
    {
        foreach (Questionsstudent item in DataSource.questionsstudents)
        {
            if(item.QuestudentId==idQ)
                return item;
        }
        throw new NotFoundIdException($"QuestionStudent with id {idQ} not found.");
    }

    public List<Questionsstudent> ReadAll()
    {
        List<Questionsstudent> values = new List<Questionsstudent>(DataSource.questionsstudents);
        return values;
    }

    public void Update(Questionsstudent item)
    {
        foreach (Questionsstudent i in DataSource.questionsstudents)
        {
            if (i.QuestudentId == item.QuestudentId)
            {
                DataSource.questionsstudents.Remove(i);
                DataSource.questionsstudents.Add(item);
                return;
            }
        }
        throw new NotFoundIdException($"QuestionStudent with id {item.QuestudentId} not found.");
    }
}
