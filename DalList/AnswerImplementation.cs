using DO;
using DalApi;
using DalList;

namespace Dal;

internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        int id = DataSource.Config.AnsId;
        DataSource.answers.Add(item);
        return id;
    }

    public void Delete(int id)
    {
        foreach (Answer item in DataSource.answers)
        {
           if(item.AnswerId == id) 
                DataSource.answers.Remove(item);
        }
    }

    public Answer? Read(int id)
    {
        foreach (Answer item in DataSource.answers)
        {
            if (item.AnswerId == id)
                return item;
        }
        return null;
    }

    public List<Answer> ReadAll()
    {
      List<Answer> list = new List<Answer>(DataSource.answers);
        return list;
    }

    public void Update(Answer item)
    {
        foreach (Answer item1 in DataSource.answers)
        {
            if (item1.AnswerId == item.AnswerId)
            {
                DataSource.answers.Remove(item1);
                Create(item);
            }
        }
    }

}
