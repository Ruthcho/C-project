using DO;
using DalApi;
using DalList;

namespace Dal;

internal class StudentImplementation : IStudent
{
    public int Create(Student item)
    {
        {        foreach (Student item1 in DataSource.students)

            if (item.Id == item1.Id)
                {
                    throw new AlreadyExistIdException("this id already exist");
                    
                }
        }
        DataSource.students.Add(item);
        return item.Id;
    }

    public void Delete(int Id)
    {
        foreach (Student item in DataSource.students)
        {
            if (item.Id == Id)
            {
                DataSource.students.Remove(item);
                return;
            }
        }
        throw new NotFoundIdException($"Student with id {Id} not found.");
    }

    public Student? Read(int Id)
    {
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
           List<Student>? newStudents = new List<Student>(DataSource.students);
        return newStudents;
    }

    public void Update(Student item) {
        foreach (Student item1 in DataSource.students)
        {
            if (item.Id == item1.Id)
            {
                DataSource.students.Add(item);
                DataSource.students.Remove(item1);
                return;
            }
        }
        throw new NotFoundIdException($"Student with id {item.Id} not found.");
    }
    
}
