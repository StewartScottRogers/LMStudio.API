using AiPrompts;
using LMStudio;
using System.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        string aiModel = "Codestral 22B v0.1";

        string[] projectFilePaths = EmbeddedPrompts.GetAllProjectFilePaths().ToArray();

        string outputFolder = BuildOutputFiles.SearchForDirectory();

        foreach (string projectFilePath in projectFilePaths)
            Xxxx.BuildProjectFiles(projectFilePath, outputFolder, aiModel);
    }


}
