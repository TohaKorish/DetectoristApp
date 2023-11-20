namespace DetectoristApp.BLL.Exceptions;

public class UsernameIsTakenException : Exception
{
    public UsernameIsTakenException(string message) : base(message)
    {
    }
}