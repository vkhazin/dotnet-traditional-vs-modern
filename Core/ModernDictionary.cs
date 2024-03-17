using System.Runtime.InteropServices.JavaScript;

namespace Core;
using Core.Exceptions;

interface IModernDictionaryGenerator
{
    // Support a wider audience of potential implementations
    // IDictionary instead of Dictionary
    // IEnumerable instead of List
    IDictionary<string, int> GetDictionary(IEnumerable<string> keys, IEnumerable<int> values);
}

public class ModernDictionary:IModernDictionaryGenerator
{
    public IDictionary<string, int> GetDictionary(IEnumerable<string> keys, IEnumerable<int> values)
    {
        // Validate compatible length
        var keysLength = keys.Count();
        var valuesLength = values.Count();
        if (keysLength != valuesLength)
            throw new IncompatibleLengthException(leftLength:keysLength, rightLength:valuesLength);

        // Validate no duplicate key
        var firstDuplicateKey = keys
            .GroupBy(key => key)
            .FirstOrDefault(g => g.Count() > 1);

        if (firstDuplicateKey != null) {
            throw new DuplicateKeyExceptions(firstDuplicateKey.Key);
        }

        // Validate no empty key
        var firstEmptyKey = keys
            .Select((key, position) => new {Key = key, Position = position})
            .FirstOrDefault(
                keyPosition => string.IsNullOrWhiteSpace(keyPosition.Key) ||
                            string.IsNullOrEmpty(keyPosition.Key)
            );

        if (firstEmptyKey != null) {
            throw new EmptyKeyExceptions(firstEmptyKey.Position);
        }
        
        // Generate Dictionary
        var output = keys.Zip(
            values, (key, value) => new { key, value})
            .ToDictionary(item => item.key, item => item.value);

        return output;
    }
}
