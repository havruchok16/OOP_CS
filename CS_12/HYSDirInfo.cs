using System;
using System.IO;

namespace CS_12
{
    static public class HYSDirInfo
    {
        static DirectoryInfo DirsParent(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
            {
                return dirInfo;
            }
            Console.WriteLine($"Name of directories: {dirInfo.Name}");
            return DirsParent(dirInfo.Parent);
        }

        static public void InfoAboutDir(string dir)
        {
            Console.WriteLine("\t\tHYS_DIR");
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                Console.WriteLine("File has not found");
                return;
            }
            Console.WriteLine($"Count of subfiles: {dirInfo.GetFiles().Length}");
            Console.WriteLine($"Count of subdirectories: {dirInfo.GetDirectories().Length}");
            Console.WriteLine($"Directory create time: {dirInfo.CreationTime}");
            Console.WriteLine("Parent directories:");
            DirsParent(dirInfo.Parent);
            Console.WriteLine();

        }
    }
}
