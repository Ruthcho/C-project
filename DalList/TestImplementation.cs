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
        foreach (Test item in DataSource.tests)
        {
            if (item.TestId == id)
            {
                DataSource.tests.Remove(item);
                LogManager.WriteToLog("DalList", "Delete", $"Test with id {id} deleted successfully");
                return;
            }
        }
        throw new NotFoundIdException($"Test with id {id} not found.");
    }

    public Test? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading test with id {id}");
        foreach (Test item in DataSource.tests)
        {
            if (item.TestId == id)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Test with id {id} read successfully");
                return item;
            }
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

    public void Update(Test item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating test with id {item.TestId}");
        foreach (Test i in DataSource.tests)
        {
            if (i.TestId == item.TestId)
            {
                DataSource.tests.Remove(i);
                DataSource.tests.Add(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Test with id {item.TestId} updated successfully");
                return;
            }
        }
        throw new NotFoundIdException($"Test with id {item.TestId} not found.");
    }
}
