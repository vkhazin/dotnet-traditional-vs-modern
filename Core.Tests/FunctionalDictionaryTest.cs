using System.Collections.Generic;
using System.Linq;
using Core;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests;

[TestClass]
[TestSubject(typeof(FunctionalDictionary))]
public class FunctionalDictionaryTest
{
    
    [TestMethod]
    [ExpectedException(typeof(Core.Exceptions.IncompatibleLengthException))]
    public void IncompatibleListsLength()
    {
        var keys = new List<string>() { "a", "b", "c" };
        var values = new List<int>() { 1, 2 };
        _ = FunctionalDictionary.GetDictionary(keys: keys, values: values);
    }
    
    [TestMethod]
    [ExpectedException(typeof(Core.Exceptions.DuplicateKeyExceptions))]
    public void DuplicateKey()
    {
        var keys = new List<string>() { "a", "a", "c" };
        var values = new List<int>() { 1, 2, 3 };
        _ = FunctionalDictionary.GetDictionary(keys: keys, values: values);
    }
    
    [TestMethod]
    [ExpectedException(typeof(Core.Exceptions.EmptyKeyExceptions))]
    public void EmptyKey()
    {
        var keys = new List<string>() { "a", " ", "c" };
        var values = new List<int>() { 1, 2, 3 };
        _ = FunctionalDictionary.GetDictionary(keys: keys, values: values);
    }
    
    [TestMethod]
    public void LongList()
    {
        List<string> keys = new List<string>();
        List<int> values = new List<int>();

        var upperLimit = 10000000;
        for (var index = 0; index <= upperLimit; index++)
        {
            keys.Add($"key{index}");
            values.Add(index);
        }
        var result = FunctionalDictionary.GetDictionary(keys: keys, values: values);
        
        Assert.AreEqual(result.Keys.Count,keys.Count);
        Assert.AreEqual(result[$"key{upperLimit - 1}"], upperLimit - 1);
    }
}