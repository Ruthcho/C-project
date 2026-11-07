using DalApi;
using DalList;
using DO;   
using System.Data;
using System.Reflection;
using Tools;
namespace Dal;

internal class QuestiosstudentImplementation : IQuestionsstudent
{
    public int Create(Questionsstudent item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Creating new question-student association");
        item.QuestudentId= DataSource.Config.QsId;
        DataSource.questionsstudents.Add(item);
        LogManager.WriteToLog("DalList", "Create", $"QuestionStudent association created with id {item.QuestudentId}");
            return item.QuestudentId;
    }

    public void Delete(int idQ)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Deleting question-student association with id {idQ}");
        foreach (Questionsstudent item in DataSource.questionsstudents)
        {
            if(item.QuestudentId==idQ)
            {
                DataSource.questionsstudents.Remove(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with id {idQ} deleted");
                return;
            }
        }
        throw new NotFoundIdException($"QuestionStudent with id {idQ} not found.");

    }

    public Questionsstudent? Read(int idQ)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading question-student association with id {idQ}");
        foreach (Questionsstudent item in DataSource.questionsstudents)
        {
            if(item.QuestudentId==idQ)
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with id {idQ} found");
                return item;
        }
        throw new NotFoundIdException($"QuestionStudent with id {idQ} not found.");
    }

    public List<Questionsstudent> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Reading all question-student associations");
        List<Questionsstudent> values = new List<Questionsstudent>(DataSource.questionsstudents);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Total question-student associations found: {values.Count}");
        return values;
    }

    public void Update(Questionsstudent item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating question-student association with id {item.QuestudentId}");
        foreach (Questionsstudent i in DataSource.questionsstudents)
        {
            if (i.QuestudentId == item.QuestudentId)
            {
                DataSource.questionsstudents.Remove(i);
                DataSource.questionsstudents.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with id {item.QuestudentId} updated");
                return;
            }
        }
        throw new NotFoundIdException($"QuestionStudent with id {item.QuestudentId} not found.");
    }
}
