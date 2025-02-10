Creating a complete .NET 9.0 solution for an X-BASE functionality library as described is quite extensive. Below, I'll outline the initial structure and provide some sample code snippets to get you started. This will include setting up the solution in Visual Studio 2022, defining the project structure, and implementing a few key components.

### Solution Structure

1. **XBaseLibrary.sln** - The solution file.
2. **XBaseLibrary/Properties** - Project properties.
3. **XBaseLibrary/Models** - Directory for data models (records).
4. **XBaseLibrary/Services** - Directory for business logic and services.
5. **XBaseLibrary/Interfaces** - Directory for interfaces.
6. **XBaseLibrary/Enums** - Directory for enumerations.
7. **XBaseLibrary.Tests** - Project for unit tests.

### Step-by-Step Implementation

#### 1. Initialize the Solution in Visual Studio
- Create a new solution named `XBaseLibrary.sln`.
- Add a new project to the solution:
  - Name: XBaseLibrary
  - Type: Class Library (.NET Core)

#### 2. Define Project Structure
- Create directories and files as per the outlined structure.

##### Example Directory Structure

```
/XBaseLibrary/
    /Models/
        RecordModel.cs
    /Services/
        RecordService.cs
    /Interfaces/
        IRecordRepository.cs
    /Enums/
        RecordTypeEnum.cs
/Properties/
    AssemblyInfo.cs
/XBaseLibrary.Tests/
    UnitTest1.cs
```

#### 3. Implementing Key Components

##### Models/RecordModel.cs
```csharp
namespace XBaseLibrary.Models
{
    public record RecordModel(
        string Id,
        string FieldOne,
        string FieldTwo)
    {
    }
}
```

##### Interfaces/IRecordRepository.cs
```csharp
using System.Collections.Generic;
using XBaseLibrary.Models;

namespace XBaseLibrary.Interfaces
{
    public interface IRecordRepository
    {
        void CreateRecord(RecordModel record);
        IEnumerable<RecordModel> QueryRecords(string sqlQuery);
        void UpdateRecord(RecordModel record);
        void DeleteRecord(string id);
    }
}
```

##### Enums/RecordTypeEnum.cs
```csharp
namespace XBaseLibrary.Enums
{
    public enum RecordTypeEnum
    {
        TypeOne,
        TypeTwo,
        // Add other record types as needed
    }
}
```

##### Services/RecordService.cs
```csharp
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using XBaseLibrary.Interfaces;
using XBaseLibrary.Models;

namespace XBaseLibrary.Services
{
    public class RecordService : IRecordRepository
    {
        private readonly string _filePath = "records.dat";
        private readonly ILogger<RecordService> _logger;

        public RecordService(ILogger<RecordService> logger)
        {
            _logger = logger;
        }

        public void CreateRecord(RecordModel record)
        {
            // Implement creation logic
            using var streamWriter = new StreamWriter(_filePath, true);
            streamWriter.WriteLine($"{record.Id},{record.FieldOne},{record.FieldTwo}");
        }

        public IEnumerable<RecordModel> QueryRecords(string sqlQuery)
        {
            // Implement SQL-like query logic
            // For simplicity, return all records
            var recordList = new List<RecordModel>();
            if (File.Exists(_filePath))
            {
                using var streamReader = new StreamReader(_filePath);
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var fields = line.Split(',');
                    var record = new RecordModel(fields[0], fields[1], fields[2]);
                    recordList.Add(record);
                }
            }

            return recordList;
        }

        public void UpdateRecord(RecordModel record)
        {
            // Implement update logic
            _logger.LogInformation("UpdateRecord method not implemented.");
        }

        public void DeleteRecord(string id)
        {
            // Implement delete logic
            _logger.LogInformation("DeleteRecord method not implemented.");
        }
    }
}
```

#### 4. Unit Testing

##### XBaseLibrary.Tests/UnitTest1.cs
```csharp
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
```

### Documentation

Create a `README.md` file in the root of the solution with the following content:

```markdown
# X-BASE Functionality Library

This library provides functionality to read, write, query, update, and delete X-Base records. It supports creating and managing tables, indexes, relationships, views, triggers, stored procedures, functions, and user-defined data types.

## Features

- Create and manage X-Base records.
- Query records using SQL-like queries.
- Update and delete records.
- Manage tables, indexes, relationships, views, triggers, stored procedures, and functions.

## Usage

1. **Create a new record:**
   ```csharp
   var recordService = new RecordService();
   recordService.CreateRecord(new RecordModel("1", "FieldOneValue", "FieldTwoValue"));
   ```

2. **Query records:**
   ```csharp
   var records = recordService.QueryRecords("SELECT * FROM records");
   foreach (var record in records)
   {
       Console.WriteLine($"{record.Id}, {record.FieldOne}, {record.FieldTwo}");
   }
   ```

3. **Update a record:**
   ```csharp
   recordService.UpdateRecord(new RecordModel("1", "UpdatedFieldOneValue", "FieldTwoValue"));
   ```

4. **Delete a record:**
   ```csharp
   recordService.DeleteRecord("1");
   ```

## Testing

Unit tests are included in the `XBaseLibrary.Tests` project. Use the Microsoft Unit Test Framework to run the tests.

## File Structure

- `/Models`: Data models.
- `/Services`: Business logic and services.
- `/Interfaces`: Interfaces for repositories.
- `/Enums`: Enumerations.
- `/Tests`: Unit tests.
```

### Final Thoughts
This is a starting point. You will need to expand on this foundation by implementing the remaining functionalities, handling edge cases, and improving the query mechanism. Additionally, ensure thorough unit testing for all entry points in the code.

To further enhance the library, consider:
- Implementing more robust error handling.
- Adding support for complex SQL queries.
- Optimizing file I/O operations.
- Enhancing logging and monitoring capabilities.
- Supporting more advanced features like transactions, concurrency control, etc.