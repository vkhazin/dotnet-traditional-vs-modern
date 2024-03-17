namespace Core.Exceptions;

public class EmptyKeyExceptions: Exception
{
    public EmptyKeyExceptions(int position) : base(message:
        string.Format(
            "An empty key was found in position: {0:n}", 
            position
        )
    )
    {
    }
}