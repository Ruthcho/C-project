using DalApi;
using DalList;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Creating new answer");
        int id = DataSource.Config.AnsId;
        item.AnswerId = id;
        DataSource.answers.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer created with id {id}");
        return id;
    }

    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Deleting answer with id {id}");
        foreach (Answer item in DataSource.answers)
            {
                if (item.AnswerId == id)
                {
                    DataSource.answers.Remove(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with id {id} deleted");
                return;
                }
                
            throw new NotFoundIdException($"Answer with id {id} not found.");
        } 
        
    }

    public Answer? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading answer with id {id}");

        foreach (Answer item in DataSource.answers)
            {
                if (item.AnswerId == id)
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with id {id} found");
            return item;
            }
        
        throw new NotFoundIdException($"Answer with id {id} not found.");
    }

    public List<Answer> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Reading all answers");

        List<Answer> list = new List<Answer>(DataSource.answers);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Total answers found: {list.Count}");
        return list;
    }

    public void Update(Answer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating answer with id {item.AnswerId}");

        foreach (Answer i in DataSource.answers)
            {
            if (i.AnswerId == item.AnswerId)
            {
                DataSource.answers.Remove(i);
                DataSource.answers.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with id {item.AnswerId} updated");
                return;
            }

            }
        throw new NotFoundIdException($"Answer with id {item.AnswerId} not found.");


    }

}
