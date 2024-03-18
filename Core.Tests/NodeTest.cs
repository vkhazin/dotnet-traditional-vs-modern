using Core;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Core.Tests;

[TestClass]
[TestSubject(typeof(Node))]
public class NodeTest
{

    [TestMethod]
    public void TestToString()
    {
        // A sample binary tree
        /*********************************
                        1
                    *       *
                4               3
            *       *               *   
        2               5               9
            *                       *
                6               8
            *              *        *
        7              -1               0
        *********************************/
        var tree = new Core.Node()
        {
            Value = 1,
            Left = new Node
            {
                Value = 4,
                Left = new Node
                {
                    Value = 2,
                    Right = new Node
                    {
                        Value = 6,
                        Left = new Node {Value = 7}
                    }
                },
                Right = new Node
                {
                    Value = 5
                }
            },
            Right = new Node
            {
                Value = 3,
                Right = new Node
                {
                    Value = 9,
                    Left = new Node
                    {
                        Value = 8,
                        Left = new Node {Value = -1 },
                        Right = new Node { Value = 0 }
                    }
                }
            }
        };
        
        var result = tree.ToString();
        Assert.AreEqual(result, "2,7,4,6,1,5,-1,3,8,9,0");
    }
}