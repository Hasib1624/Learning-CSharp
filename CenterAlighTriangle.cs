using System;
using System.Text;

public class Program
{
    public static void Main() {
        StringBuilder triangle = new StringBuilder();
        int n = 4;
        for(int i = 1;i <= n;i++)
        {
            for(int j = 0;j < i;j++){
                triangle.Append('*');
            }
            triangle.Append('\n');
        }
        Console.Write(triangle);
        // |triangle| = n(n+1)/2 + n
        
        string centered = GetCentered(triangle.ToString(),n);
        Console.Write(centered);
        // |centered| = n(n+1)/2 + n + n(n-1)
    }
    public static string GetCentered(string triangle,int n)
    {
        StringBuilder sb = new StringBuilder();
        string delimiter = " ";
        
        int i = 0,j = 0;
        bool firstChar = true;
        while(j < triangle.Length && i < n)
        {
            if(firstChar){
                for(int nSpace = 0;nSpace < (n - i - 1);nSpace++)
                    sb.Append(delimiter);
                firstChar = false;
            }
            if(triangle[j] == '\n'){
                sb[sb.Length - 1] = '\n';
                firstChar = true;
                i++;
            }else{
                sb.Append($"{triangle[j]}{delimiter}");
            }
            j++;
        }
        return sb.ToString();
    }
}