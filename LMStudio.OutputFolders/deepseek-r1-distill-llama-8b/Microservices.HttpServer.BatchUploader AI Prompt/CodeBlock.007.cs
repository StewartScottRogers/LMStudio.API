using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var fileName = "testfile.txt";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        using (var fileStream = File.OpenRead(filePath))
            await UploadToServer(fileName, fileStream);
    }

    static async Task UploadToServer(string fileName, Stream fileContent)
    {
        var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };
        
        try
        {
            using (var content = new MultipartStreamContent())
            {
                content.AddStream(fileContent, "form-data", fileName);
                
                var response = await client.PostAsync("Upload", content);
                
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Failed to upload file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static async Task<T> GetJson<T>(HttpContent content)
    {
        var data = await content.ReadAsAsync<T>();
        return data;
    }
}