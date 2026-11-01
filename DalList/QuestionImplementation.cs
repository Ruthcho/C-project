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
        foreach(Question item in DataSource.questions)
        {
            if(item.IdQuestion==id)
            {
                DataSource.questions.Remove(item);
                return;
            }
        }
        throw new NotFoundIdException($"Question with id {id} not found.");
    }

    public Question? Read(int id)
    {
        foreach (Question item in DataSource.questions)
        {
            if(item.IdQuestion==id)
                return item;
        }
        throw new NotFoundIdException($"Question with id {id} not found.");
    }

    public List<Question> ReadAll()
    {
        List<Question> list = new List<Question>(DataSource.questions);
        return list;
    }

    public void Update(Question item)
    {
        foreach(Question i in DataSource.questions)
        {
            if(i.IdQuestion==item.IdQuestion)
            {
                DataSource.questions.Remove(i);
                DataSource.questions.Add(item);
                return;
            }
        }
        throw new NotFoundIdException($"Question with id {item.IdQuestion} not found.");
    }
}
