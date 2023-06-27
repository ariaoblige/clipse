using System;
using System.Linq;

namespace Clipse {
  public class Subfn {
    public static string GetDirName(string path) {
      string reversePath = new string(path.Reverse().ToArray());
      string tempname = "";
      foreach(var character in reversePath) {
        if (character=='\\' || character=='/') {
          break;
        }
        tempname += character;
      }
      var finalname = "";
      for (var c = tempname.Length-1; c>=0; c--) {
        finalname += tempname[c];
      }

      return finalname;
    }
  }
}
