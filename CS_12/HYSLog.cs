using System;
using System.IO;

namespace CS_12
{
    public static class HYSLog
    {
        static public StreamWriter writerLog;
        static HYSLog()
        {
            using (writerLog = new StreamWriter(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSLog.txt", false))
                writerLog.WriteLine("\t\tHYS_LOG");
        }
        static public void WriteToHYSLog(string action, string fileName = "", string path = "")
        {
            using (writerLog = new StreamWriter(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSLog.txt", true))
            {
                DateTime time = new DateTime();
                time = DateTime.Now;

                writerLog.WriteLine();

                if (fileName.Length != 0)
                    writerLog.WriteLine($"File name: {fileName}");

                if (path.Length != 0)
                    writerLog.WriteLine($"Path: {path}");

                writerLog.WriteLine($"Time: {time.ToLocalTime()}");
                writerLog.WriteLine();

                writerLog.WriteLine($"Action: {action}");
                writerLog.WriteLine();
            }
        }

    }
}
