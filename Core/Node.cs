using System.Text;

namespace Core;

public class Node
{
    public int? Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }


    public override string ToString()
    {
        var list = new List<NodeWithPosition>();
        ParseTree(this,0,0, ref list);
        
        var orderedList = 
            list.OrderBy(item => item.Column)
            .ThenBy(item => item.Row);
        
        var orderedValues = 
            orderedList.Select(item => item.Value);
        
        return string.Join(",", orderedValues);
    }

    struct NodeWithPosition
    {
        public int Value;
        public int Row;
        public int Column;
    }
    
    private void ParseTree(Node node, int row, int column, ref List<NodeWithPosition> list)
    {
        if (node.Left is not null)
            ParseTree(node.Left, row + 1, column - 1, ref list);

        if (node.Right is not null)
            ParseTree(node.Right, row + 1, column + 1, ref list);
        
        if (node.Value.HasValue)
            list.Add(new NodeWithPosition
            {
                Value = node.Value.Value,
                Row = row,
                Column = column
            });
    }
}