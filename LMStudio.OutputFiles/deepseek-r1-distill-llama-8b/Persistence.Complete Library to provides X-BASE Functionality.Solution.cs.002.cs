using XBase.Library;

// Create a database context
var options = new DbContextOptions<InMemoryDatabase>
{
    UseInMemoryDatabase = true,
    EnableLazyLoading = false,
    CommandTimeout = 1
};

var dbContext = new InMemoryDatabase(options);
var tableRepository = new TableRepository(dbContext);

// Create a sample table and add it to the database
var sampleTable = new Table 
{ 
    Name = "Orders",
    Columns = new Column[] 
    { 
        new Column { Name = "OrderId", DataType = typeof(int) },
        new Column { Name = "OrderDate", DataType = typeof(DateTime) }
    }
};

dbContext.Tables.AddAsync(sampleTable);

// Add a sample row
var newRow = new Row 
{ 
    Id = 1,
    OrderDate = DateTime.Now
};

tableRepository.AddRowAsync(newRow, "Orders");