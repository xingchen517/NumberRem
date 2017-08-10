using System;
using System.Text;

public class RandomGenerator
{
    public static string GetLongNumber(int digit)
    {
        var sb = new StringBuilder();
        Random rnd = new Random();
        for (int i=0;i<digit;i++)
        {            
            sb.Append(rnd.Next(0, 9));
        }
        return sb.ToString();
    }
}