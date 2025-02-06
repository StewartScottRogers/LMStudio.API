using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace LMStudio
{
    public static class BuildCsFiles
    {
        public static string SearchForDirectory(string directoryName, int levelsUp)
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

        public static void WriteAllText(string path, string contents)
        {

            Contract.Requires(path != null);
            Contract.Requires(path.Length > 0);

            Encoding encoding = Encoding.UTF8;

            using (StreamWriter sw = new StreamWriter(path, false, encoding))
                sw.Write(contents);
        }

    }
}
