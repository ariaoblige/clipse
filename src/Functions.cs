using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Clipse {
  public class Functions {
    public static void CreateProject() {
      string[] arg = Environment.GetCommandLineArgs();
      
      if (arg.Length==3) {
        var projectpath = Directory.GetCurrentDirectory()+"/"+arg[2];
        Directory.CreateDirectory(projectpath);
        Directory.CreateDirectory(projectpath+"/src");
        Directory.CreateDirectory(projectpath+"/bin");
        
        File.WriteAllText(projectpath+"/src/Main.java",
            "public class Main {\n  public static void main(String[] args) {\n    \n  }\n}");
        Visuals.ChangeColor(fg:ConsoleColor.Green, write:"Successfully created project '"+arg[2]+"'.");
      }
      else if (arg.Length==2) {
        Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Expected a name for the project.");
      }
      else {
        Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Expected two arguments.");
      }
    }


    public static void CompileProject() {
      if (!Directory.Exists(Directory.GetCurrentDirectory()+"/src")) {
        Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Couldn't find ./src directory. Make sure you're running this at the project's main directory.");
      }
      else {
        Visuals.ChangeColor(fg:ConsoleColor.Yellow, write:"\nRunning javac...");
        ProcessStartInfo processinfo = new ProcessStartInfo("cmd.exe", "/C javac src/*.java -d bin");
        processinfo.UseShellExecute = false;
        var process = Process.Start(processinfo);
        process.WaitForExit();
      }
    }


    public static void CreateClass() {
      string[] arg = Environment.GetCommandLineArgs();
      if (arg.Length==3) {
        if (arg[2].Contains(".")) {
          Visuals.ChangeColor(fg:ConsoleColor.Red, write:"'.' characters are not valid.");
        }
        else {
          var path = Directory.GetCurrentDirectory()+"\\";
          if (path.Contains("src")) {
            var parent = Directory.GetCurrentDirectory().ToString();
            var package = "";
            var pkgnames = new List<string> { };
            while (Subfn.GetDirName(parent)!="src") {
              pkgnames.Add(Subfn.GetDirName(parent));
              parent = Directory.GetParent(parent).ToString();
            }
            var revpkgnames = pkgnames.ToArray();
            Array.Reverse(revpkgnames);
            foreach (string pkg in revpkgnames) {
              if (pkg == Subfn.GetDirName(Directory.GetCurrentDirectory())) {
                package += pkg;
              }
              else {
                package += pkg+".";
              }
            }
            string pkgstring = "package "+package+";\n\n";
            if (package=="") { pkgstring = ""; }
            File.WriteAllText(Directory.GetCurrentDirectory()+"\\"+arg[2]+".java", pkgstring+"public class "+arg[2]+" {\n  \n}");
            Visuals.ChangeColor(fg:ConsoleColor.Green, write:"Successfully created class '"+arg[2]+".java'.");
          }
          else {
            Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Expected to be running inside a ~\\src directory.");
          }
        }
      }
      else if (arg.Length==2) {
        Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Expected a class name.");
      }
      else if (arg.Length>3) {
        Visuals.ChangeColor(fg:ConsoleColor.Red, write:"Expected two arguments (command and class name).");
      }
    }
  }
}
