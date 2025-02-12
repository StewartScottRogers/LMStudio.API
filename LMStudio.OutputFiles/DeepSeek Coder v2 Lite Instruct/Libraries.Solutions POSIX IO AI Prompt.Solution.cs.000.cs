namespace POSIXIO.FileDescriptorManager
{
    public class FileDescriptorManager
    {
        private readonly Dictionary<int, Stream> _descriptors;

        public FileDescriptorManager()
        {
            _descriptors = new Dictionary<int, Stream>
            {
                [0] = Console.OpenStandardInput(),
                [1] = Console.OpenStandardOutput(),
                [2] = Console.OpenStandardError()
            };
        }

        public void AddDescriptor(int descriptor, Stream stream)
        {
            _descriptors[descriptor] = stream;
        }

        // Other methods for managing descriptors...
    }
}