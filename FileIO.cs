using System;
using System.IO;

public class FileIO
{
    public static void Main(string[] args)
    {
        // File IO in C#
        string path = "numbers.txt";

        // reads all lines as string array and closes the file
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }

        // reading line by line
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }// using statement takes care of the disposing of StreamReader

        path = "text.txt";
        lines = new string[] { "This is a line1", "This is a line2" };

        // write lines and closes the file
        File.WriteAllLines(path, lines);
        // append lines and closes the file
        File.AppendAllLines(path, lines);
        // append string
        File.AppendAllText(path, "Final line!");

        // write one line at a time
        // using (StreamWriter sw = File.CreateText(path))
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine("one1");
            sw.WriteLine("two");
            sw.WriteLine("three");
        }

        Console.WriteLine("Done Writting!");
    }
}