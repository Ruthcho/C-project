using DalApi;
using DalList;
using DO;

namespace Dal;

internal class QuestionImplementation : IQuestion
{
    public int Create(Question item)
    {
        int id = DataSource.Config.QuesId;
        item.IdQuestion =id;
        DataSource.questions.Add(item);
        return id;
    }

    public void Delete(int id)
    {
        foreach (Question item in DataSource.questions)
        {
           if(item.IdQuestion==id) 
                DataSource.questions.Remove(item);
        }
    }

    public Question? Read(int id)
    {
        foreach (Question item in DataSource.questions)
        {
            if(item.IdQuestion==id)
                return item;
        }
        return null;
    }

    public List<Question> ReadAll()
    {
        List<Question> list = new List<Question>(DataSource.questions);
        return list;
    }

    public void Update(Question item)
    {
        foreach (Question item1 in DataSource.questions)
        {
            if (item1.IdQuestion == item.IdQuestion)
            {
                DataSource.questions.Remove(item1);
                Create(item);
            }

        }
    }
}
