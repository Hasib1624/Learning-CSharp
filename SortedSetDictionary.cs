using System;
using System.Collections.Generic;

// Sorted Set Sorted Dictionary are just like Hash Set and Hash Dictionary
// Has similar functionality but implemented with Binary Search Tree to maintain sorted order
// If you are coming from C++, std::set (SortedSet), std::map (SortedDictionary)

public class CustomComparer : IComparer<int>
{
    public int Compare(int a,int b)
    {
        return b - a;
    }
}

public class SortedSetDictionary
{
    public static void Main(string[] args)
    {
        // SortedSet (like c++ set) (Balanced Binary Search Tree)
        Console.WriteLine("Sorted Set Demo");
        // default
        SortedSet<int> sortedSet = new SortedSet<int>();
        
        // with initial IEnumerable type
        // int[] a = new int[] {6,0,3,10,-1};
        // SortedSet<int> sortedSet = new SortedSet<int>(a);
        
        // with custom comparer
        // SortedSet<int> sortedSet = new SortedSet<int>(new CustomComparer());
        
        // with initial IEnumerable type and custom comparer
        // SortedSet<int> sortedSet = new SortedSet<int>(a,new CustomComparer());
        
        // Add: O(lg n)
        sortedSet.Add(6);
        sortedSet.Add(0);
        sortedSet.Add(3);
        sortedSet.Add(10);
        sortedSet.Add(-1);
        
        // contains O(lg n)
        Console.WriteLine($"sortedSet contains 3? {sortedSet.Contains(3)}");
        Console.WriteLine($"sortedSet contains 2? {sortedSet.Contains(2)}");
        
        // Remove: O(lg n)
        sortedSet.Remove(3);
        
        foreach(int num in sortedSet)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        
        Console.WriteLine($"Count {sortedSet.Count}");
        // ** Min Max in O(1) time (This allows us to use this like Priority Queue)
        Console.WriteLine($"Min {sortedSet.Min}");
        Console.WriteLine($"Max {sortedSet.Max}");
        
        // Supports Some Set Operation. See doc for details
        
        // Sorted Dictionary (like c++ map) (Balanced Binary Search Tree)
        // Sorted on key
        Console.WriteLine("Sorted Dictionary Demo");
        SortedDictionary<int,string> map = new SortedDictionary<int,string>();
        // also supports constructor
        // SortedDictionary<TKey,TValue>(IComparer<TKey>)
        // SortedDictionary<TKey,TValue>(IDictionary<TKey,TValue>)
        // SortedDictionary<TKey,TValue>(IDictionary<TKey,TValue>, IComparer<TKey>)
        
        // Add: O(lg n)
        map.Add(3,"D");
        map.Add(0,"A");
        map.Add(4,"E");
        map.Add(2,"C");
        map.Add(1,"B");
        
        // Remove: O(lg n)
        map.Remove(3);
        
        // access by key: O(lg n)
        Console.WriteLine($"access by key map[{0}] = {map[0]}");
        
        // contains O(lg n)
        Console.WriteLine($"map contains key 3? {map.ContainsKey(3)}");
        Console.WriteLine($"map contains key 2? {map.ContainsKey(2)}");
        
        // Loop through all
        foreach (KeyValuePair<int,string> keyValue in map)
        {
            Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
        }
    }
}