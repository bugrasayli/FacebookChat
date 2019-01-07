using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class FileOpp
    {
        private string Html;
        public void Write(string Path, string Data)
        {
            string FilePath = Path;
            //"C:\Users\cobhc\Onedrive\Masaüstü\Facebook.txt";
            try
            {
                StreamWriter sw = new StreamWriter(FilePath);
                sw.Write(Data);
                sw.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        public string AllRead(string Path)
        {
            string Html = System.IO.File.ReadAllText(Path);
            // path example : @"C:\Users\Public\TestFolder\WriteText.txt"
            return Html;
        }
        public string[] ReadWithLine(string path)
        {
            string[] Html = System.IO.File.ReadAllLines(path);
            return Html;
        }
        public void WriteLine(string Path,string[] data)
        {
            StreamWriter sw = new StreamWriter(Path);
            sw.Write(data[1]);
        }
    }
}
