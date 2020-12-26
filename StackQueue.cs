using System;
using System.Collections;
using System.Collections.Generic;

// This deals with common used of Stack and Queue
// see documentation for details
class StackQueue
{
    public static void Main(string[] args)
    {
        // Stack
        Console.WriteLine("Stack Demo");
        
        Stack<int> s = new Stack<int>();
        // can also be created from iterable
        // Stack<int> s = new Stack<int>(new int[] { 2, 12, 26, -2 });

        s.Push(2);
        s.Push(12);
        s.Push(26);
        s.Push(-2);

        // also supports contains: O(n)
        Console.WriteLine($"s consins 26? {s.Contains(26)}");
        Console.WriteLine($"s consins 64? {s.Contains(64)}");

        // there is no isEmpty!
        while (s.Count != 0)
        {
            // only peeks not remove
            int top = s.Peek();
            // pop and return. **not like c++ pop
            top = s.Pop();
            Console.WriteLine(top);
        }

        // Queue
        Console.WriteLine("Queue Demo");
        
        Queue<int> q = new Queue<int>();
        // can also be created from iterable
        // Queue<int> q = new Queue<int>(new int[] { 2, 12, 26, -2 });

        q.Enqueue(2);
        q.Enqueue(12);
        q.Enqueue(26);
        q.Enqueue(-2);

        // also supports contains: O(n)
        Console.WriteLine($"q consins 26? {q.Contains(26)}");
        Console.WriteLine($"q consins 64? {q.Contains(64)}");

        // there is no isEmpty!
        while (q.Count != 0)
        {
            // only peeks not remove
            int front = q.Peek();
            // pop and return. **not like c++ pop
            front = q.Dequeue();
            Console.WriteLine(front);
        }
   }
}