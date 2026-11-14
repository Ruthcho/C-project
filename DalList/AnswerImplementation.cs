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
        Answer a = DataSource.answers.FirstOrDefault<Answer>(an => an.AnswerId==id );
                if (a!=null)
                {
                    DataSource.answers.Remove(a);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with id {id} deleted");
                return;
                }
                
            throw new NotFoundIdException($"Answer with id {id} not found.");
        } 
        
   

    public Answer? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading answer with id {id}");
        Answer answer = DataSource.answers.FirstOrDefault<Answer>(a=>a.AnswerId==id);
        
                if (answer!=null) { 
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with id {id} found");
            return answer;
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

    public Answer ReadDet(Func<Answer, bool> filter)
    {
        Answer a = DataSource.answers.FirstOrDefault<Answer>(filter);
        if (a != null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with det read successfully");
            return a;
        }
        throw new NotFoundIdException($"Answer not found.");
    }

    public void Update(Answer item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating answer with id {item.AnswerId}");

        Answer answer = DataSource.answers.FirstOrDefault<Answer>(a => a.AnswerId == item.AnswerId);
        if (answer!=null)
            {
                DataSource.answers.Remove(answer);
                DataSource.answers.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Answer with id {item.AnswerId} updated");
                return;
            }

            
        throw new NotFoundIdException($"Answer with id {item.AnswerId} not found.");


    }

}
