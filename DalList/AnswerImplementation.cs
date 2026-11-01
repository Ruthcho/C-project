using DO;
using DalApi;
using DalList;

namespace Dal;

internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        int id = DataSource.Config.AnsId;
        item.AnswerId = id;
        DataSource.answers.Add(item);
        return id;
    }

    public void Delete(int id)
    {
           foreach (Answer item in DataSource.answers)
            {
                if (item.AnswerId == id)
                {
                    DataSource.answers.Remove(item);
                    return;
                }

                throw new NotFoundIdException($"Answer with id {id} not found.");
        } 
        
    }

    public Answer? Read(int id)
    {
        
            foreach (Answer item in DataSource.answers)
            {
                if (item.AnswerId == id)
                    return item;
            }
       
       throw new NotFoundIdException($"Answer with id {id} not found.");
    }

    public List<Answer> ReadAll()
    {

      List<Answer> list = new List<Answer>(DataSource.answers);
        return list;
    }

    public void Update(Answer item)
    {
        
            foreach (Answer i in DataSource.answers)
            {
            if (i.AnswerId == item.AnswerId)
            {
                DataSource.answers.Remove(i);
                DataSource.answers.Add(item);
                return;
            }

            }
            throw new NotFoundIdException($"Answer with id {item.AnswerId} not found.");


    }

}
