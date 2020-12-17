using System;
using System.IO;
using System.IO.Compression;

namespace CS_12
{
    class Program
    {
        static void Main(string[] args)
        {
            HYSDiskInfo.InfoAboutDisk();
            HYSLog.WriteToHYSLog("HYSDiskInfo.InfoAboutDisk()");

            HYSFileInfo.InfoAboutFile(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSLog.txt");
            HYSLog.WriteToHYSLog("HYSFileInfo.InfoAboutFile()", "HYSLog.txt", @"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSLog.txt");

            HYSDirInfo.InfoAboutDir(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12");
            HYSLog.WriteToHYSLog("HYSDirInfo.InfoAboutDir()", "", @"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12");

            HYSFileManager.AllDirsAndFilesOfDisk(@"C:\");
            HYSLog.WriteToHYSLog("HYSFileManager.AllDirsAndFilesOfDisk()", "", @"C:\");

            HYSFileManager.AllFilesWithExtension(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\compiler-course-project-", ".txt");
            HYSLog.WriteToHYSLog("HYSFileManager.AllFilesWithExtension()", "", "C:\\Users\\37544\\Desktop\\C#\\CS_12\\CS_12\\compiler - course - project - ");

            HYSFileManager.CreateZIP(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSInspect\HYSFiles");
            HYSLog.WriteToHYSLog("HYSFileManager.CreateZIP()");
        }
    }
}
