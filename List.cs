using System;
using System.Collections.Generic;

// This deals with common used of List; see documentation for details
// If you are coming from C++, like std::vector (List)
// If you want to learn about Sorting List, see SortingWithLibraryFunctions.cs

class List
{
    public static void Main(string[] args)
    {
        // Dynamic Array
        Console.WriteLine("List Demo");
        
        List<int> nums = new List<int>() { 1, 2, 3, 6 };
        
        // add to end: ammortized O(1)
        nums.Add(6);
        nums.Add(66);
        nums.Add(-5);
        
        // add any enumurable objects
        nums.AddRange(new int[] { 1, 6, 1 });
        List<int> otherList = new List<int> { 4, 2, 0 };
        nums.AddRange(otherList);
        
        // removs at an index: O(n)
        nums.RemoveAt(0);
        
        // iterate over list element using foreach loop (Read-Write)
        Console.WriteLine("List for print");
        for(int i = 0;i < nums.Count;++i)
        {
            // access nums[i] O(1)
            Console.Write(nums[i] + " ");
        }
        Console.WriteLine();
        
        // iterate over list element using foreach loop (Read Only)
        Console.WriteLine("List foreach print");
        foreach (int num in nums)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // convert to a fixed size array
        int[] toArray = nums.ToArray();
        Console.WriteLine("List after ToArray");
        foreach (int num in toArray)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}