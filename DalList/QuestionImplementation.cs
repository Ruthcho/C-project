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
        Question item = DataSource.questions.FirstOrDefault<Question>(q=> q.IdQuestion==id);

        if (item != null)
        {
            DataSource.questions.Remove(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question with id {id} deleted");
            return;
        }
        
        throw new NotFoundIdException($"Question with id {id} not found.");
    }

    public Question? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name , $"Reading question with id {id}");
        Question question = DataSource.questions.FirstOrDefault<Question>(q => q.IdQuestion == id);
        if (question != null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $" question with id {id} readed");
            return question;
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

    public Question  ReadDet(Func<Question, bool> filter)
    {
        Question q = DataSource.questions.FirstOrDefault<Question>(filter);
        if (q != null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question with det read successfully");
            return q;
        }
        throw new NotFoundIdException($"Question not found.");
    }

    public void Update(Question item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating question with id {item.IdQuestion}");
        Question question=DataSource.questions.FirstOrDefault<Question>(q => q.IdQuestion == item.IdQuestion);
        if (question != null)
        {
            DataSource.questions.Remove(question);
            DataSource.questions.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Question with id {item.IdQuestion} updated");
        }
        throw new NotFoundIdException($"Question with id {item.IdQuestion} not found.");
    }
}
