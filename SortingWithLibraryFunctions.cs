using System;
using System.Collections;
using System.Collections.Generic;

public class Point : IComparable<Point>
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x = 0, double y = 0)
    {
        this.X = x;
        this.Y = y;
    }

    // IComparable.CompareTo for default comparison
    public int CompareTo(Point other)
    {
        if (this.X != other.X)
            return (this.X < other.X) ? -1 : 1;
        if (this.Y != other.Y)
            return (this.Y < other.Y) ? -1 : 1;
        return 0;
    }

    public override string ToString()
    {
        return String.Format("({0},{1})", this.X, this.Y);
        // new String Interpolation Syntex
        // return $"{this.X},{this.Y})";
    }
}

public class PointComparer : IComparer<Point>
{
    public int Compare(Point p1, Point p2)
    {
        double originDist1 = p1.X * p1.X + p1.Y * p1.Y;
        double originDist2 = p2.X * p2.X + p2.Y * p2.Y;
        if (originDist1 == originDist2)
            return 0;
        return (originDist1 < originDist2) ? -1 : 1;
    }
}

public delegate int PointComareDelegate(Point p1, Point p2);
class Sorting
{
    public static void Main(string[] args)
    {
        int[] a = new int[] { 1, 31, 0, -6, 50, 0, 41, 19, 0, 13, 0 };
        Console.WriteLine("Before Sorting");
        Show(a);

        // default sorting accending
        Array.Sort(a);

        // custom comapre function -> int cmp(int a,int b)
        // cmp(a,b) - (-ve) a comes before
        //          - (+ve) a comes after
        //          -   0   a == b

        // Lambda Function 
        // (x, y) => y - x : sorts decending
        Array.Sort(a, (x, y) => y - x);

        // multi statement Lambda
        // sorts according to last digit
        Array.Sort(a, (x, y) =>
        {
            int x_last = Math.Abs(x % 10);
            int y_last = Math.Abs(y % 10);
            return x_last - y_last;
        });

        // cmp(0,x) = 1,cmp(x,0) = -1 else accending
        // this treats 0 like infinity and thus moves 0 to last
        Array.Sort(a, (x, y) =>
        {
            if (x == 0) return 1;
            if (y == 0) return -1;
            return x - y;
        });

        Console.WriteLine("After Sorting");
        Show(a);

        // Sort Generic List
        List<int> b = new List<int>() { 1, 31, 0, -6, 50, 0, 41, 19, 0, 13, 0 };
        Console.WriteLine("b Before Sorting");
        Show(b);

        // default compare function
        b.Sort();

        // custom compare function
        b.Sort((x, y) => y - x);

        b.Sort((x, y) =>
        {
            int x_last = Math.Abs(x % 10);
            int y_last = Math.Abs(y % 10);
            return x_last - y_last;
        });

        Console.WriteLine("b After Sorting");
        Show(b);

        // Sort Custom Class
        List<Point> points = new List<Point>(){
            new Point(1,3),
            new Point(3,3),
            new Point(6,-3),
            new Point(-1,-3),
            new Point(1,-3),
            new Point(3,2),
            new Point(6,3),
            new Point(3,0)
        };
        Console.WriteLine("points Before Sorting");
        Show(points);

        // to Sort with default. The class has to implement IComparable interface
        points.Sort();

        // provide custom compare function can also be provided
        // this function sorts by distance from the origin
        points.Sort((p1, p2) =>
        {
            double originDist1 = p1.X * p1.X + p1.Y * p1.Y;
            double originDist2 = p2.X * p2.X + p2.Y * p2.Y;
            if (originDist1 == originDist2)
                return 0;
            return (originDist1 < originDist2) ? -1 : 1;
        });

        // Comparer class can also be provided instead of Lambda
        points.Sort(new PointComparer());

        Console.WriteLine("points After Sorting");
        Show(points);
    }

    private static void Show(IEnumerable a)
    {
        foreach (var ai in a)
        {
            Console.Write(ai + " ");
        }
        Console.WriteLine();
    }
}