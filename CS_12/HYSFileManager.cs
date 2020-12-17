using System;
using System.IO;
using System.IO.Compression;

namespace CS_12
{
    static public class HYSFileManager
    {
        static public void AllDirsAndFilesOfDisk(string diskName)
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                if (drive.Name == diskName)
                {
                    DirectoryInfo dir = new DirectoryInfo(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12");
                    if (dir.GetDirectories("HYSInspect").Length == 0)
                    {
                        DirectoryInfo subDir = dir.CreateSubdirectory("HYSInspect");
                        DirectoryInfo dr = new DirectoryInfo(diskName);
                        using (StreamWriter file = new StreamWriter(subDir.FullName + @"\" + "HYSdirinfo.txt"))
                        {
                            file.WriteLine("\t\tDirectories");
                            foreach (var d in dr.GetDirectories())
                            {
                                file.WriteLine($"{d.Name}");
                            }
                            file.WriteLine();
                            file.WriteLine("\t\tFiles");
                            foreach (var d in dr.GetFiles())
                            {
                                file.WriteLine($"{d.Name}");
                            }
                            file.WriteLine();
                        }
                        FileInfo dirinfo = new FileInfo(subDir.FullName + @"\" + "HYSdirinfo.txt");
                        dirinfo.CopyTo(subDir.FullName + @"\" + "HYSdirinfoCOPY.txt");
                        dirinfo.Delete();
                    }
                    break;
                }
            }
        }

        static public void AllFilesWithExtension(string dirPath, string extension)
        {
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (directory.Exists)
            {
                DirectoryInfo temp = new DirectoryInfo(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12");
                if (temp.GetDirectories("HYSFiles").Length == 0 && temp.GetDirectories("HYSInspect")[0].GetDirectories("HYSFiles").Length == 0)
                {
                    DirectoryInfo Files = temp.CreateSubdirectory("HYSFiles");

                    foreach (var file in directory.GetFiles($"*{extension}"))
                    {
                        file.CopyTo(Files.FullName + @"\" + file.Name);
                    }

                    Files.MoveTo(temp.GetDirectories("HYSInspect")[0].FullName + "\\HYSFiles");
                }
            }
        }

        static public void CreateZIP(string dir)
        {
            string zipName = @"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSInspect\HYSFiles.zip";
            if (new DirectoryInfo(@"C:\Users\37544\Desktop\C#\CS_labs\CS_12\CS_12\HYSInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(dir, zipName);
                DirectoryInfo direct = new DirectoryInfo(dir);
                foreach (var innerFile in direct.GetFiles())
                {
                    innerFile.Delete();
                }
                direct.Delete();
                ZipFile.ExtractToDirectory(zipName, dir);
            }
        }
    }
}
