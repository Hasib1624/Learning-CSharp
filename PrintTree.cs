using System;
using System.Text;
using System.Collections.Generic;

public class Node
{
    public string Name;
    public List<Node> Children;
    
    public Node(string name)
    {
        Name = name;
        Children = new List<Node>();
    }
    
    public void AddChild(Node n)
    {
        Children.Add(n);
    }
    
    public string GetTree()
    {
        StringBuilder tree = new StringBuilder();
        BuildTree(tree,"");
        return tree.ToString();
    }
    
    private void BuildTree(StringBuilder tree,string space)
    {
        tree.Append($"{space}--{Name}\n");
        space += "  |";
        foreach(Node child in Children)
        {
            child.BuildTree(tree,space);
        }
    }
}

class Program
{
    static void Main() {
        Node a = new Node("A");
        Node b = new Node("B");
        Node c = new Node("C");
        Node d = new Node("D");
        Node e = new Node("E");
        Node f = new Node("F");
        Node g = new Node("G");
        Node h = new Node("H");
        Node i = new Node("I");
        Node j = new Node("J");
        
        c.AddChild(e);
        c.AddChild(f);
        
        h.AddChild(j);
        
        b.AddChild(g);
        b.AddChild(h);
        b.AddChild(i);
        
        a.AddChild(b);
        a.AddChild(c);
        a.AddChild(d);
        
        Console.WriteLine(a.GetTree());
    }
}