using System;
using System.Collections.Generic;

// This deals with common used of HashSet and Dictionary 
// Both are implemented with Hash Table to achieve amortized O(1) time
// If you are coming from C++, std::unordered_set (HashSet) std::unordered_map (Dictionary)

class HashSetDictionary
{
    public static void Main(string[] args)
    {
        // Demo array for HashSet,HashTable
        int[] a = new int[] { 1, 9, 5, 1, 2, 3, 6, 4, 1, 2, 3, 6, 5, 8 };

        // HashSet
        Console.WriteLine("HashSet Demo");
        HashSet<int> seen = new HashSet<int>();
        // important constructors
        // HashSet<T>(Int32 capacity) 
        // ** if you already have idea about the size,this reduces resizing
        //    and makes the insertion faster
        // HashSet<T>(IEnumerable<T>)
        // HashSet<T>(IEqualityComparer<T>)
        // HashSet<T>(IEnumerable<T>, IEqualityComparer<T>)
        // HashSet<T>(Int32 capcity, IEqualityComparer<T>)
        
        
        foreach (int ai in a)
        {
            // Add: O(1)
            seen.Add(ai);
        }
        // same thing can be achived directly by doing this
        // HashSet<int> seen = new HashSet<int>(a);

        // supports Contains: O(1)
        Console.WriteLine($"seen contains 2? {seen.Contains(2)}");
        Console.WriteLine($"seen contains 0? {seen.Contains(0)}");

        // remove: O(1)
        seen.Remove(8);

        // loop through all
        Console.Write("full seen HashSet: ");
        foreach (int ai in seen)
        {
            Console.Write(ai + " ");
        }
        Console.WriteLine();
        // also supports set operation: See Documentation
        // UnionWith()
        // IntersectWith()
        // Overlaps()
        // ExceptWith()
        // SymmetricExceptWith()
        // IsSubsetOf()
        // IsProperSubsetOf()
        // IsSupersetOf()
        // IsProperSupersetOf()
        // SetEquals()


        // Dictionary
        // **Dictionary maintains insertion order
        Console.WriteLine("Dictionary Demo");
        Dictionary<int, int> countOccurance = new Dictionary<int, int>();
        foreach (int ai in a)
        {
            // without already exising, exception is thrown
            if (!countOccurance.ContainsKey(ai))
            {
                // storing new value: O(1)
                countOccurance[ai] = 0;
                // can also be added this way
                // countOccurance.Add(ai, 0);
            }

            // getting and modifying entry: O(1)
            countOccurance[ai]++;
        }

        // removes entry by key: O(1)
        countOccurance.Remove(8);

        // loop through all
        Console.WriteLine("full countOccurance: ");
        foreach (KeyValuePair<int, int> keyValue in countOccurance)
        {
            Console.WriteLine($"{keyValue.Key} -> {keyValue.Value}");
        }
    }
}