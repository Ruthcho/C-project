
namespace DO;

public class MyEcxception:Exception
{

    public MyEcxception(string message):base(message)
    {
    }

    public MyEcxception(string message, Exception innerException):base(message,innerException)
    {
    }
}

public class NotFoundIdException:MyEcxception
{
    public NotFoundIdException(string message):base(message)
    {
        Console.WriteLine("not found this id");
    }
}

public class AlreadyExistIdException:MyEcxception
{
    public AlreadyExistIdException(string message):base(message)
    {
        Console.WriteLine("already exist this id");
    }
}
 public class EmptyListException: MyEcxception
{
    public EmptyListException(string message):base(message)
    {
        Console.WriteLine("the list is empty");
    }
}

