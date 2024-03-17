namespace Core.Exceptions;

public class DuplicateKeyExceptions: Exception
{
    public DuplicateKeyExceptions(string key) : base(message:
        string.Format(
            "A duplicate key {0} found", 
            key
        )
    )
    {
    }
}