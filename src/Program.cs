using System;
using System.Collections.Generic;
using Clipse;

namespace Clipse {
  public class Program {
    public static void Main(String[] args) {
      List<string[]> cmd = new List<string[]>() { };
      cmd.Add(new string[] { "nprj", "newproj" });
      cmd.Add(new string[] { "cprj", "compile", "cp" });
      cmd.Add(new string[] { "ncls", "newclass", "cc" });

      var operations = new Dictionary<string[], Action>() { };

      operations.Add(cmd[0], () => Functions.CreateProject() );
      operations.Add(cmd[1], () => Functions.CompileProject() );
      operations.Add(cmd[2], () => Functions.CreateClass() );
      
      var help = new Dictionary<string[], string> { };

      help.Add(cmd[0], "Creates a new Java project.");
      help.Add(cmd[1], "Compiles a project from the root folder");
      help.Add(cmd[2], "Creates a new class including a template.");

      int oplen = 0;
      foreach(var fn in operations) { oplen++; }

      // Start executing
      
      string[] command = new string[] { };
      if (args.Length>0) {
        foreach(var c in cmd) {
          foreach(var alias in c) {
            if (args[0]==alias) { command = c; }
          }
        }
        try {
          operations[command]();
        }
        catch(Exception e){
          Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Argument does not coincide with an operation.");
          Console.WriteLine(e);
        }
      }
      else {
        Visuals.ChangeColor(ConsoleColor.Blue, ConsoleColor.Black);
        Console.WriteLine("clipse ver.:0.1.1.\n");
        Console.ResetColor();
        
        foreach(var helper in help) {
          for (int c=0; c<helper.Key.Length; c++) {
            if (c==0) {
              Visuals.ChangeColor(write:helper.Key[c], fg:ConsoleColor.Yellow);
            }
            else if (c==1) {
              Visuals.ChangeColorLine("aliases: "+helper.Key[c], ConsoleColor.DarkGray);
            }
            else {
              Visuals.ChangeColorLine(", "+helper.Key[c], ConsoleColor.DarkGray);
            }
            if (c==helper.Key.Length-1) { Console.Write("\n"); }
          }
          Visuals.ChangeColor(write:"  "+helper.Value, fg:ConsoleColor.Blue);
        }
      }
    }
  }
}
