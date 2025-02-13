using AiPrompts;
using LMStudio;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] aiModels
            = {
                 "DeepSeek Coder v2 Lite Instruct"      //  0
                ,"Qwen2.5 Coder 32B Instruct"           //  1
                ,"Mistral Small 24B Instruct 2501"      //  2
                ,"deepseek-r1-distill-llama-8b"         //  3
            };

        string aiModel = aiModels[3];

        string[] projectFilePaths = EmbeddedPrompts.GetAllProjectFilePaths().ToArray();

        string outputFolder = ProjectFileManager.GetOutputFolder();

        foreach (string projectFilePath in projectFilePaths)
            ProjectFileManager.BuildProjectFiles(projectFilePath, outputFolder, aiModel);
    }
}
