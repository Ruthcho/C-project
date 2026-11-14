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
            Student student = DataSource.students.FirstOrDefault<Student>(s => s.Id == item.Id);

                if (student != null)
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
        Student student= DataSource.students.FirstOrDefault(s => s.Id == Id);
            if (student!=null)
            {
                DataSource.students.Remove(student);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Student with id {Id} deleted successfully");
                return;
            }
        
        throw new NotFoundIdException($"Student with id {Id} not found.");
    }

    public Student? Read(int Id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading student with id {Id}");
        Student student = DataSource.students.FirstOrDefault(s => s.Id == Id);
            if (student!=null)
            {
                return student;
            }


        
        throw new NotFoundIdException($"Student with id {Id} not found.");
    }

    public List<Student> ReadAll()
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Reading all students");
        List<Student>? newStudents = new List<Student>(DataSource.students);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Total students found: {newStudents.Count}");
        return newStudents;
    }

    public Student ReadDet(Func<Student, bool> filter)
    {
        Student s = DataSource.students.FirstOrDefault<Student>(filter);
        if (s != null)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Student with det read successfully");
            return s;
        }
        throw new NotFoundIdException($"Student not found.");
    }

    public void Update(Student item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Updating student with id {item.Id}");
        Student student =DataSource.students.FirstOrDefault<Student>(s=>s.Id == item.Id);
            if (student!=null)
            {
                DataSource.students.Add(item);
                DataSource.students.Remove(student);
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"Student with id {item.Id} updated successfully");
                return;
            }
        
        throw new NotFoundIdException($"Student with id {item.Id} not found.");
    }

}
