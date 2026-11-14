using DO;
using DalApi;
using DalList;
using Tools;
using System.Reflection;

namespace Dal;

internal class TestImplementation : ITest
{
    public int Create(Test item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Creating test with id {item.TestId}");
        int id = DataSource.Config.TestId;
        item.TestId = id;
       DataSource.tests.Add(item);
        LogManager.WriteToLog("DalList", "Create", $"Test with id {item.TestId} created successfully");
        return id;
    }

    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Deleting test with id {id}");
        Test test = DataSource.tests.FirstOrDefault<Test>(t=>t.TestId==id);
            if (test!=null)
            {
                DataSource.tests.Remove(test);
                LogManager.WriteToLog("DalList", "Delete", $"Test with id {id} deleted successfully");
                return;
            }
        
        throw new NotFoundIdException($"Test with id {id} not found.");
    }

    public Test? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading test with id {id}");
        Test test = DataSource.tests.FirstOrDefault<Test>(t => t.TestId == id);
        if (test!=null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Test with id {id} read successfully");
                return test;
            }
        
        throw new NotFoundIdException($"Test with id {id} not found.");
    }

    public List<Test> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading all tests");
        List<Test> values = new List<Test>(DataSource.tests);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Tests read successfully");
        return values;
    }

    public Test ReadDet(Func<Test, bool> filter)
    {
        Test t = DataSource.tests.FirstOrDefault<Test>(filter);
        if (t != null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Test with det read successfully");
            return t;
        }
        throw new NotFoundIdException($"Test not found.");
    }

    public void Update(Test item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating test with id {item.TestId}");
        Test test= DataSource.tests.FirstOrDefault<Test>(t => t.TestId == item.TestId);
        if (test!=null)
            {
                DataSource.tests.Remove(test);
                DataSource.tests.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Test with id {item.TestId} updated successfully");
                return;
            }
        
        throw new NotFoundIdException($"Test with id {item.TestId} not found.");
    }
    
}
