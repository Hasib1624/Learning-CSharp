using System;
using System.Text;

public class Program
{
	public static void Main(string[] args)
	{
		
		string line = "This is a long line which have to be wrapped to fit in a line where line width is given. This problem appeared in my first job interview! I was nervous and made some silly mistakes :(.";
		
		Console.WriteLine("--String Before--");
		Console.WriteLine(line);

		string wrappedLine = GetWrapped(line,60);
		
		Console.WriteLine("--String After--");
		Console.WriteLine(wrappedLine);
	}

	public static string GetWrapped(string text,int lineWidth)
	{
		StringBuilder word = new StringBuilder();
		StringBuilder wrappedText = new StringBuilder();

		int inThisLine = 0;
		bool isFirstWord = true;
		
		for(int i = 0;i <= text.Length;i++)
		{
			if(i == text.Length || text[i] == ' ')
			{
				string toAppend;
				if(isFirstWord)
				{
					toAppend = word.ToString();
					isFirstWord = false;
				}else
				{
					toAppend = $" {word}";
				}

				if(inThisLine + toAppend.Length > lineWidth)
				{
					wrappedText.Append($"\r\n{word}");
					inThisLine = word.Length;
				}else
				{
					wrappedText.Append(toAppend);
					inThisLine += toAppend.Length;
				}
				
				word = new StringBuilder();
			}else
			{
				word.Append(text[i]);
			}
		}
		return wrappedText.ToString();
	}
}
