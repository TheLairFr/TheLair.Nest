using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLair.Nest.Infra;

public class Output
{
    public static void DisplayInfo(string data)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Write("Info");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(": ");
        Console.WriteLine(data);
    }

    public static void DisplayError(string data)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("Error");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(": ");
        Console.WriteLine(data);
    }
}