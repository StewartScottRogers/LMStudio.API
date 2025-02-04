using System;
using System.IO;

namespace AiPrompt.Library
{
    public static class BuildSolutionPrompts
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

    }
}
