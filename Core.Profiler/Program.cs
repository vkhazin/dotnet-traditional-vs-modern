using Core;

Console.WriteLine("Profile traditional dictionary");

var upperLimit = 10000000;
List<string> keys = new List<string>();
List<int> values = new List<int>();
    
for (var index = 0; index <= upperLimit; index++)
{
    keys.Add($"key{index}");
    values.Add(index);
}

//_ = (new TraditionalDictionary()).GetDictionary(keys: keys, values: values);
//_ = (new ModernDictionary()).GetDictionary(keys: keys, values: values);
_ = FunctionalDictionary.GetDictionary(keys: keys, values: values);