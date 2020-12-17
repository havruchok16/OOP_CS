using System;
using System.IO;


namespace CS_12
{
    static public class HYSDiskInfo
    {
        static public void InfoAboutDisk()
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                Console.WriteLine("\t\tHYS_DRIVE");
                Console.WriteLine($"Drive name: {drive.Name}");
                Console.WriteLine($"Drive type: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                    Console.WriteLine($"File system: {drive.DriveFormat}");
                    Console.WriteLine($"Root: {drive.RootDirectory}");
                    Console.WriteLine($"Total size: {drive.TotalSize / Math.Pow(10, 9)} Gbyte");
                    Console.WriteLine($"Free size: {drive.TotalFreeSpace / Math.Pow(10, 9)} Gbyte");
                    Console.WriteLine($"Available: {drive.AvailableFreeSpace / Math.Pow(10, 9)} Gbyte");
                    Console.WriteLine();
                }

            }
        }
    }
}
