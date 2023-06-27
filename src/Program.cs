using System;
using System.Collections.Generic;
using Clipse;

namespace Clipse {
  public class Program {
    public static void Main(String[] args) {
      string[] cmd = new string[] {
        "nprj",
        "cprj",
        "ncls",
      };

      var operations = new Dictionary<string, Action>() { };

      operations.Add(cmd[0], () => Functions.CreateProject() );
      operations.Add(cmd[1], () => Functions.CompileProject() );
      operations.Add(cmd[2], () => Functions.CreateClass() );
      
      var help = new SortedDictionary<string, string> { };

      help.Add(cmd[0], "Creates a new Java project.");
      help.Add(cmd[1], "Compiles a project from the root folder");
      help.Add(cmd[2], "Creates a new class including a template.");

      int oplen = 0;
      foreach(var fn in operations) { oplen++; }

      // Start executing
      
      try {
        var answer = args[0];
        
        try {
          operations[answer]();
        }
        catch(Exception e){
          Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Argument does not coincide with an operation.");
          Console.WriteLine(e);
        }
      }
      catch {
        Visuals.ChangeColor(ConsoleColor.Blue, ConsoleColor.Black);
        Console.WriteLine("clipse ver.:0.1.1.\n");
        Console.ResetColor();
        
        foreach(var helper in help) {
          Console.WriteLine(helper.Key);
          Console.WriteLine("    "+helper.Value);
        }
      }
    }
  }
}
