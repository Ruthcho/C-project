using System;

public record Questionsstudent
{
public	int studentId;
    public int testId;
	public int questionId;
	public int choosenAnswer;
	public int QuestudentId;
public Questionsstudent(int studentId,int testId, int questionId,int answerId)
	{
		this.studentId = studentId;
		this.testId = testId;
		this.questionId = questionId;
		this.choosenAnswer = answerId;

	}
	public Questionsstudent() { }
}
