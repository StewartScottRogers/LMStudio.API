var simulator = new FileSystemSimulator();
int fd = simulator.Open("testfile");
simulator.Write(fd, new byte[] { 65, 66, 67 }); // Write "ABC"
byte[] buffer = new byte[10];
simulator.Read(fd, buffer, 0);
simulator.Close(fd);