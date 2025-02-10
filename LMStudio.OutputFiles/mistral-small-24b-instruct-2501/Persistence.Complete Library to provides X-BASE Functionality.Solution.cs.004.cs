using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XBaseLibrary.Interfaces;
using XBaseLibrary.Models;

namespace XBaseLibrary.Tests
{
    [TestClass]
    public class RecordServiceTests
    {
        private Mock<IRecordRepository> _recordRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            _recordRepositoryMock = new Mock<IRecordRepository>();
        }

        [TestMethod]
        public void QueryRecords_ReturnsNonEmptyList_WhenRecordsExist()
        {
            // Arrange
            var recordModel = new RecordModel("1", "FieldOneValue", "FieldTwoValue");
            _recordRepositoryMock.Setup(repo => repo.QueryRecords(It.IsAny<string>())).Returns(new List<RecordModel> { recordModel });

            // Act
            var result = _recordRepositoryMock.Object.QueryRecords("SELECT * FROM records");

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void CreateRecord_CallsCreateMethod_WhenCalled()
        {
            // Arrange
            var recordModel = new RecordModel("1", "FieldOneValue", "FieldTwoValue");
            _recordRepositoryMock.Setup(repo => repo.CreateRecord(recordModel)).Verifiable();

            // Act
            _recordRepositoryMock.Object.CreateRecord(recordModel);

            // Assert
            _recordRepositoryMock.Verify(repo => repo.CreateRecord(recordModel), Times.Once);
        }

        [TestMethod]
        public void UpdateRecord_CallsUpdateMethod_WhenCalled()
        {
            // Arrange
            var recordModel = new RecordModel("1", "FieldOneValue", "FieldTwoValue");
            _recordRepositoryMock.Setup(repo => repo.UpdateRecord(recordModel)).Verifiable();

            // Act
            _recordRepositoryMock.Object.UpdateRecord(recordModel);

            // Assert
            _recordRepositoryMock.Verify(repo => repo.UpdateRecord(recordModel), Times.Once);
        }

        [TestMethod]
        public void DeleteRecord_CallsDeleteMethod_WhenCalled()
        {
            // Arrange
            string recordId = "1";
            _recordRepositoryMock.Setup(repo => repo.DeleteRecord(recordId)).Verifiable();

            // Act
            _recordRepositoryMock.Object.DeleteRecord(recordId);

            // Assert
            _recordRepositoryMock.Verify(repo => repo.DeleteRecord(recordId), Times.Once);
        }
    }
}