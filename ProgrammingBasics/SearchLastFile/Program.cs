using System;
using System.Collections.Generic;
using System.IO;

namespace SearchLastFile
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> filesInfo = FileUtil.GetLastCreatedFilesByFormat(ResourcesUtil.DataFolder, FileFormat.Bmp);
            FileUtil.PrintFilesInfo(filesInfo);
            Console.ReadLine();
        }        
    }
}
