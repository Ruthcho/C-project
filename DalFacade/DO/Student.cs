using System;

public class Student
{
	public int Id;
	public string? name;
    public int testId;
	public int mark;
	public Student(int id, string name, int testId, int mark)
	{
        this.Id = id;
        this.name = name;
        this.testId = testId;
        this.mark = mark;

    }
		

	public Student()
	{
	}
}
