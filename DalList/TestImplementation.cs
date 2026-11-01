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
            if (item.TestId == id)
            {
                DataSource.tests.Remove(item);
                return;
            }
        }
        throw new NotFoundIdException($"Test with id {id} not found.");
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
        throw new NotFoundIdException($"Test with id {id} not found.");
    }

    public List<Test> ReadAll()
    {
        List<Test> values = new List<Test>(DataSource.tests);
        return values;
    }

    public void Update(Test item)
    {
        foreach (Test i in DataSource.tests)
        {
            if (i.TestId == item.TestId)
            {
                DataSource.tests.Remove(i);
                DataSource.tests.Add(item);
                return;
            }
        }

        throw new NotFoundIdException($"Test with id {item.TestId} not found.");
    }
}
