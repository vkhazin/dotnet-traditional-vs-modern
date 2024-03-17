using Core;

Console.WriteLine("Profile traditional dictionary");

void ProfileTraditionalDictionary()
{
    List<string> keys = new List<string>();
    List<int> values = new List<int>();

    var upperLimit = 10000000;
    for (var index = 0; index <= upperLimit; index++)
    {
        keys.Add($"key{index}");
        values.Add(index);
    }
    _ = (new TraditionalDictionary()).GetDictionary(keys: keys, values: values);
}
ProfileTraditionalDictionary();

Console.WriteLine("Profile modern dictionary");

void ProfileModernDictionary()
{
    List<string> keys = new List<string>();
    List<int> values = new List<int>();

    var upperLimit = 10000000;
    for (var index = 0; index <= upperLimit; index++)
    {
        keys.Add($"key{index}");
        values.Add(index);
    }
    _ = (new ModernDictionary()).GetDictionary(keys: keys, values: values);
}
//ProfileModernDictionary();