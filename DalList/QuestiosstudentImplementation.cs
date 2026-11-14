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
       Questionsstudent questionsstudent=DataSource.questionsstudents.FirstOrDefault<Questionsstudent>(q=>q.QuestudentId==idQ);
            if(questionsstudent!=null)
            {
                DataSource.questionsstudents.Remove(questionsstudent);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with id {idQ} deleted");
                return;
            }
        
        throw new NotFoundIdException($"QuestionStudent with id {idQ} not found.");

    }

    public Questionsstudent? Read(int idQ)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading question-student association with id {idQ}");
        Questionsstudent questionsstudent = DataSource.questionsstudents.FirstOrDefault<Questionsstudent>(q => q.QuestudentId == idQ);
        if (questionsstudent != null) { 
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with id {idQ} found");
                return questionsstudent;
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

    public Questionsstudent ReadDet(Func<Questionsstudent, bool> filter)
    {
        Questionsstudent q = DataSource.questionsstudents.FirstOrDefault<Questionsstudent>(filter);
        if (q != null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with det read successfully");
            return q;
        }
        throw new NotFoundIdException($"QuestionStudent not found.");
    }

    public void Update(Questionsstudent item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating question-student association with id {item.QuestudentId}");
        Questionsstudent questionsstudent = DataSource.questionsstudents.FirstOrDefault<Questionsstudent>(q => q.QuestudentId == item.QuestudentId);
        if (questionsstudent!=null)
            {
                DataSource.questionsstudents.Remove(questionsstudent);
                DataSource.questionsstudents.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"QuestionStudent association with id {item.QuestudentId} updated");
                return;
            }
       
        throw new NotFoundIdException($"QuestionStudent with id {item.QuestudentId} not found.");
    }
}
