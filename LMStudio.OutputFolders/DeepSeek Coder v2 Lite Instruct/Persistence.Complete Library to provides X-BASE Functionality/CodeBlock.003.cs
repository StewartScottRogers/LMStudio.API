using Xunit;
using XBaseLibrary.Entities;
using XBaseLibrary.Repositories;

namespace XBaseLibraryTests.UnitTests
{
    public class RecordRepositoryTests
    {
        [Fact]
        public void AddAndGetRecord()
        {
            var repository = new RecordRepository();
            var record = new Record(1, "Test Data");

            repository.AddRecord(record);
            var result = repository.GetRecordById(1);

            Assert.Equal(record, result);
        }
    }
}