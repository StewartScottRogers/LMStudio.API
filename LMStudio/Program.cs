using AiPrompts;
using LMStudio;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string aiModel = "DeepSeek Coder v2 Lite Instruct";

        string[] projectFilePaths = EmbeddedPrompts.GetAllProjectFilePaths().ToArray();

        string outputFolder = ProjectFileManager.GetOutputFolder();

        foreach (string projectFilePath in projectFilePaths)
            ProjectFileManager.BuildProjectFiles(projectFilePath, outputFolder, aiModel);
    }
}
