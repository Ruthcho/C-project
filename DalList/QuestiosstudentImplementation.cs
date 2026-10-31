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
        foreach (Questionsstudent item1 in DataSource.questionsstudents)
        {
            if(item.QuestudentId==item1.QuestudentId)
                return -1;

        }
        DataSource.questionsstudents.Add(item);
            return item.QuestudentId;
    }

    public void Delete(int idQ)
    {
        foreach (Questionsstudent item in DataSource.questionsstudents)
        {
            if(item.QuestudentId==idQ)
                DataSource.questionsstudents.Remove(item);
        }


    }

    public Questionsstudent? Read(int idQ)
    {
        foreach (Questionsstudent item in DataSource.questionsstudents)
        {
            if(item.QuestudentId==idQ)
                return item;
        }
        return null;
    }

    public List<Questionsstudent> ReadAll()
    {
        List<Questionsstudent> values = new List<Questionsstudent>(DataSource.questionsstudents);
        return values;
    }

    public void Update(Questionsstudent item)
    {
        foreach(Questionsstudent item1 in DataSource.questionsstudents)
        {
            if (item.QuestudentId== item1.QuestudentId)
            {
                DataSource.questionsstudents.Remove(item1);
                DataSource.questionsstudents.Add(item);   
            }

        }
    }
}
