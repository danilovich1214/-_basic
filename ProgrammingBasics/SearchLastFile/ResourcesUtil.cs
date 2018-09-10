using System;
using System.IO;

namespace SearchLastFile
{
    public class ResourcesUtil
    {
        public static string BinPath { get; private set; }
        public static string DataFolder { get; private set; }        

        static ResourcesUtil()
        {
            BinPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            if (String.IsNullOrEmpty(BinPath))
                throw new Exception("Unable to find out the assembly codebase path");

            DataFolder = Path.Combine(BinPath, "FilesFolder");            
        }
    }
}
