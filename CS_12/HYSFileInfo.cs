using System;
using System.IO;

namespace CS_12
{
    static public class HYSFileInfo
    {
        static public void InfoAboutFile(string file)
        {
            System.Console.WriteLine("\t\tHYS_FILE");
            FileInfo fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
            {
                Console.WriteLine("File has not found");
                return;
            }
            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Full path: {fileInfo.FullName}");
            Console.WriteLine($"Size: {fileInfo.Length} byte");
            Console.WriteLine($"Full extension: {fileInfo.Extension}");
            Console.WriteLine($"Full create time: {fileInfo.CreationTime}");
            Console.WriteLine();
        }
    }
}
