using DO;
using DalApi;
using DalList;
using Tools;
using System.Reflection;

namespace Dal;

internal class StudentImplementation : IStudent
{
    public int Create(Student item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Creating student with id {item.Id}");
        {
            foreach (Student item1 in DataSource.students)

                if (item.Id == item1.Id)
                {
                    throw new AlreadyExistIdException("this id already exist");

                }
        }
        DataSource.students.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Student with id {item.Id} created successfully");
        return item.Id;
    }

    public void Delete(int Id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Deleting student with id {Id}");
        foreach (Student item in DataSource.students)
        {
            if (item.Id == Id)
            {
                DataSource.students.Remove(item);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Student with id {Id} deleted successfully");
                return;
            }
        }
        throw new NotFoundIdException($"Student with id {Id} not found.");
    }

    public Student? Read(int Id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading student with id {Id}");
        foreach (Student item in DataSource.students)
        {
            if (item.Id == Id)
            {
                return item;
            }


        }
        throw new NotFoundIdException($"Student with id {Id} not found.");
    }

    public List<Student> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading all students");
        List<Student>? newStudents = new List<Student>(DataSource.students);
        LogManager.WriteToLog("DalList", "ReadAll", $"Total students found: {newStudents.Count}");
        return newStudents;
    }

    public void Update(Student item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating student with id {item.Id}");
        foreach (Student item1 in DataSource.students)
        {
            if (item.Id == item1.Id)
            {
                DataSource.students.Add(item);
                DataSource.students.Remove(item1);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Student with id {item.Id} updated successfully");
                return;
            }
        }
        throw new NotFoundIdException($"Student with id {item.Id} not found.");
    }

}
