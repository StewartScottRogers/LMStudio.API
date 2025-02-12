var fileSystem = new FileSystem();
int fd = fileSystem.Open("testfile.txt", FileModeEnum.ReadOnly);
byte[] buffer = new byte[5];
int bytesRead = fileSystem.Read(fd, buffer, 5);

string resultString = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
Console.WriteLine(resultString); // Outputs "Hello"