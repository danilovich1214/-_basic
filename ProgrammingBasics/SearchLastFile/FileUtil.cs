using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace SearchLastFile
{
    public class FileUtil
    {
        private const int SECONDS_TO_COMPARE = 10;

        public static List<FileInfo> GetLastCreatedFilesByFormat(string folderPath, FileFormat fileFormat)
        {            
            FileInfo[] allFilesInfo = GetAllFilesByPathAndFormat(folderPath, fileFormat);

            FileInfo lastCreatedFile = allFilesInfo.OrderByDescending(f => f.CreationTime).FirstOrDefault();
            List<FileInfo> resultFileInfo = new List<FileInfo>
            {
                lastCreatedFile
            };            

            if (allFilesInfo.Count() > 1)
            {                
                foreach (FileInfo fileInfo in allFilesInfo)
                {                    
                    if (DateTime.Compare(lastCreatedFile.CreationTime.AddSeconds(-SECONDS_TO_COMPARE), fileInfo.CreationTime) < 0 && lastCreatedFile.Name != fileInfo.Name)
                    {
                        resultFileInfo.Add(fileInfo);
                    }
                }                
            }            

            return resultFileInfo;                
        }

        public static FileInfo[] GetAllFilesByPathAndFormat(string folderPath, FileFormat fileFormat)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            Console.WriteLine("Files folder: " + folderPath);

            FileInfo[] allFilesInfo = directory.GetFiles($"*{fileFormat.ToDescription()}");
            if (allFilesInfo.Count() == 0)
            {
                throw new FileNotFoundException("Не найдено файлов в формате " + fileFormat);
            }
            Console.WriteLine($"Files count in format: {fileFormat.ToDescription()}" + allFilesInfo.Count());

            return allFilesInfo;
        }

        public static void PrintFilesInfo(List<FileInfo> filesInfo)
        {
            Console.WriteLine("\nResult files info:");
            foreach (FileInfo file in filesInfo)
            {
                Console.WriteLine($"FileName: {file.Name} | Creation Time: {file.CreationTime}");
            }
        }
    }

    public enum FileFormat
    {
        [Description(".txt")]
        Txt,
        [Description(".bmp")]
        Bmp
    }
}