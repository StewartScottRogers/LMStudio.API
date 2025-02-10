using Xunit;
using System.Collections.Generic;
using XBase.Library;

public class TableRepositoryTests : IDisposable
{
    private readonly InMemoryDatabase _database;
    private readonly TableRepository _tableRepo;
    private readonly Table _sampleTable;

    public TableRepositoryTests()
    {
        var options = new DbContextOptions<InMemoryDatabase>
        {
            UseInMemoryDatabase = true,
            EnableLazyLoading = false,
            CommandTimeout = 1
        };

        _database = new InMemoryDatabase(options);
        _tableRepo = new TableRepository(_database);
        
        // Create Sample Data
        _sampleTable = new Table 
        { 
            Name = "Customers", 
            Columns = new Column[ 
                { 
                    new Column { Name = "Id", DataType = typeof(int) },
                    new Column { Name = "Name", DataType = typeof(string) }
                }
            ]
        };
        
        _database Tables .AddAsync(_sampleTable);
    }

    [Fact]
    public async Task CreateAndRetrieveTable()
    {
        // Create Table
        bool result = await _tableRepo.CreateTableAsync(_sampleTable);
        Assert.True(result, "Failed to create table");

        // Get Table
        var retrievedTable = await _tableRepo.GetTableAsync(_sampleTable.Name);
        Assert.NotNull(retrievedTable, "Failed to retrieve table");
        
        // Verify Table Properties
        Assert.Equal(_sampleTable.Name, retrievedTable.Name);
        Assert.Equal(2, retrievedTable.Columns.Count);
    }

    [Fact]
    public async Task AddRow()
    {
        var newRow = new Row 
        { 
            Id = 1,
            Name = "John Doe",
            CreatedDate = DateTime.Now
        };
        
        bool result = await _tableRepo.AddRowAsync(newRow, _sampleTable.Name);
        Assert.True(result, "Failed to add row");

        // Verify Added Row
        var table = await _tableRepo.GetTableAsync(_sampleTable.Name);
        Assert.NotNull(table);
        Assert.Equal(3, table.Rows.Count);
    }

    public void Dispose()
    {
        _database.Dispose();
    }
}