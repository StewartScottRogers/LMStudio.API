using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace LMStudio.Libraries
{
    public static class FileSystemManagement
    {
        public static string GetSiblingFolder(string directoryName, int levelsUp = 6)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            for (int index = 0; index < levelsUp; index++)
            {
                string targetDirectory = Path.Combine(currentDirectory, directoryName);
                if (Directory.Exists(targetDirectory))
                    return targetDirectory;

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                if (currentDirectory == null)
                    break;
            }

            return string.Empty;
        }
        public static void WriteAllText(string filePath, string text)
        {
            Contract.Requires(filePath != null);
            Contract.Requires(filePath.Length > 0);
            using StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            streamWriter.Write(text);
        }

    }
}
