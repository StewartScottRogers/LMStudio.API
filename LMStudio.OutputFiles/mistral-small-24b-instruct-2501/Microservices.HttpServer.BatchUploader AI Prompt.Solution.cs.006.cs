using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BatchUploaderApi.Tests.Services
{
    [TestClass]
    public class AzureBlobStorageServiceTests
    {
        private readonly IConfiguration configuration;

        public AzureBlobStorageServiceTests()
        {
            this.configuration = new ConfigurationBuilder().Build();
        }

        // Add more unit tests for bounding conditions and edge cases here...
    }
}