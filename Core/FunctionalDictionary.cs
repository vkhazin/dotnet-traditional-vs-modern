using System.Runtime.InteropServices.JavaScript;

namespace Core;
using Core.Exceptions;

public static class FunctionalDictionary
{
    public static IDictionary<string, int> GetDictionary(IEnumerable<string> keys, IEnumerable<int> values)
    {
        // Validate compatible length
        var enumerableKeys = keys as string[] ?? keys.ToArray();
        var keysLength = enumerableKeys.Length;
        
        var enumerableValues = values as int[] ?? values.ToArray();
        
        var valuesLength = enumerableValues.Length;
        if (keysLength != valuesLength)
            throw new IncompatibleLengthException(leftLength:keysLength, rightLength:valuesLength);

        // Validate no duplicate key
        var firstDuplicateKey = enumerableKeys
            .GroupBy(key => key)
            .SelectMany(g => g.Skip(1))
            .FirstOrDefault();
        
        if (firstDuplicateKey != null) {
            throw new DuplicateKeyExceptions(firstDuplicateKey);
        }
       
        // Validate no empty key
        if (enumerableKeys.Any(key => string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key)))
        {
            throw new EmptyKeyExceptions(
                enumerableKeys
                    .Select((key, position) => new {Key = key, Position = position})
                    .First()
                    .Position
                );
        }

        // Generate Dictionary
        var output =
            enumerableKeys.Zip(
                    enumerableValues, (key, value) => new { key, value})
                .ToDictionary(item => item.key, item => item.value);

        return output;
    }
}
