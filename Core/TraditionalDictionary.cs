namespace Core;
using Core.Exceptions;

interface ITraditionalDictionaryGenerator
{
    Dictionary<string, int> GetDictionary(List<string> keys, List<int> values);
}

public class TraditionalDictionary:ITraditionalDictionaryGenerator
{
    public Dictionary<string, int> GetDictionary(List<string> keys, List<int> values)
    {
        // Validate compatible length
        var keysLength = keys.Count;
        var valuesLength = values.Count;
        if (keysLength != valuesLength)
            throw new IncompatibleLengthException(leftLength:keysLength, rightLength:valuesLength);

        var output = new Dictionary<string, int>(keys.Count);

        // Iterate through the lists
        for (int position = 0; position < keysLength; position++)
        {
            var key = keys[position];
            
            // Validate non-empty key
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                throw new EmptyKeyExceptions(position:position);
            
            // Validate non-duplicate key
            if (output.ContainsKey(key))
                throw new DuplicateKeyExceptions(key:key);

            // Extract value from the list
            var value = values[position];
            
            // Add key/value to the output dictionary
            output.Add(key: key, value: value);
        }
        
        return output;
    }
}
