
using System;

namespace Clipse {
  public class Visuals {
    public static void ChangeColor(ConsoleColor bg=ConsoleColor.Black, ConsoleColor fg=ConsoleColor.Gray,string write="") {
      Console.ForegroundColor = fg;
      Console.BackgroundColor = bg;
      if (write!="") {
        Console.WriteLine(write);
        Console.ResetColor();
      }
    }


    public static void ChangeColorLine(string write, ConsoleColor fg=ConsoleColor.Gray, ConsoleColor bg=ConsoleColor.Black) {
      Console.ForegroundColor = fg;
      Console.BackgroundColor = bg;
      Console.Write(write);
      Console.ResetColor();
    }
  }
}

