using DalApi;
using DalList;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class QuestionImplementation : IQuestion
{
    public int Create(Question item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,  "Creating new question");
        int id = DataSource.Config.QuesId;
        item.IdQuestion =id;
        DataSource.questions.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question created with id {id}");
        return id;
    }

    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName ,MethodBase.GetCurrentMethod().Name, $"Deleting question with id {id}");
        foreach (Question item in DataSource.questions)
        {
            if(item.IdQuestion==id)
            {
                DataSource.questions.Remove(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question with id {id} deleted");
                return;
            }
        }
        throw new NotFoundIdException($"Question with id {id} not found.");
    }

    public Question? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name , $"Reading question with id {id}");
        foreach (Question item in DataSource.questions)
        {
            if(item.IdQuestion==id)
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question with id {id} found");
            return item;
        }
        throw new NotFoundIdException($"Question with id {id} not found.");
    }

    public List<Question> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Reading all questions");
        List<Question> list = new List<Question>(DataSource.questions);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Total questions found: {list.Count}");
        return list;
    }

    public void Update(Question item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating question with id {item.IdQuestion}");
        foreach (Question i in DataSource.questions)
        {
            if(i.IdQuestion==item.IdQuestion)
            {
                DataSource.questions.Remove(i);
                DataSource.questions.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question with id {item.IdQuestion} updated");
                return;
            }
        }
        throw new NotFoundIdException($"Question with id {item.IdQuestion} not found.");
    }
}
