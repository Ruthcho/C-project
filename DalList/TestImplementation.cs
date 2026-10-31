using DO;
using DalApi;
using DalList;



namespace Dal;

internal class TestImplementation : ITest
{
    public int Create(Test item)
    {
        int id = DataSource.Config.TestId;
        item.TestId = id;
       DataSource.tests.Add(item);
        return id;
    }

    public void Delete(int id)
    {
        foreach (Test item in DataSource.tests)
        {
            if(item.TestId==id)
                {
                DataSource.tests.Remove(item);
                return;
            }
        }
    }

    public Test? Read(int id)
    {

        foreach (Test item in DataSource.tests)
        {
            if (item.TestId == id)
            {
                return item;
            }
        }
        return null;
    }

    public List<Test> ReadAll()
    {
        List<Test> values = new List<Test>(DataSource.tests);
        return values;
    }

    public void Update(Test item)
    {
        foreach (Test item1 in DataSource.tests)
        {
            if (item.TestId == item1.TestId)
            {
                DataSource.tests.Remove(item1);
                DataSource.tests.Add(item);
            }
        }
    }
}
