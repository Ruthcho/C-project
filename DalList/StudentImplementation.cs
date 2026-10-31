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

                return -1;
        }
        DataSource.students.Add(item);
        return item.Id;
    }

    public void Delete(int Id)
    {
        foreach (Student item in DataSource.students)
        {
            if(item.Id==Id)
                DataSource.students.Remove(item);
            
        }
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

        return null;
    }

    public List<Student> ReadAll()
    {
           List<Student>? newStudents = new List<Student>(DataSource.students);
        return newStudents;
    }

    public void Update(Student item) {
        foreach (Student item1 in DataSource.students)
        {
            if(item1.Id== item.Id) {
          DataSource.students.Remove(item1);
            Create(item1);
            }
        }
    } 
    
}
