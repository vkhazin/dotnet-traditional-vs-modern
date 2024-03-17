namespace Core.Exceptions;

public class IncompatibleLengthException : Exception
{
    public IncompatibleLengthException(int leftLength, int rightLength) 
        : base(
            message: string.Format(
                "Incompatible length: left list has {0:n} elements, while right list has {1:n} elements",
                leftLength,
                rightLength
            )
        )
    {
    }
}