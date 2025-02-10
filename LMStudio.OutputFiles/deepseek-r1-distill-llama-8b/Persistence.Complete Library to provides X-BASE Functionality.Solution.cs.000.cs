using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public record Table 
{
    public string Name { get; }
    public IEnumerable<Column> Columns { get; }
}

public record Column 
{
    public string Name { get; }
    public Type DataType { get; }
    public bool IsPrimaryKey { get; set; } = false;
    public bool IsUnique { get; set; } = false;
}

public class Row : IEquatable<Row>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public override bool Equals(Row other)
    {
        return this.Id == other.Id && 
               (this.Name == other.Name || string.IsNullOrEmpty(other.Name));
    }
}

public interface ITable
{
    ValueTask<Table> GetTableAsync(string tableName);
    ValueTask<bool> CreateTableAsync(Table table);
    ValueTask<bool> DropTableAsync(string tableName);
    ValueTask<Row> AddRowAsync(Row row, string tableName);
    ValueTask<bool> UpdateRowAsync(Row updatedRow, string tableName);
    ValueTask<bool> DeleteRowAsync(int id, string tableName);
}

public interface IColumn
{
    ValueTask<Column> GetColumnAsync(string columnName, string tableName);
    ValueTask<bool> CreateColumnAsync(Column column, string tableName);
    ValueTask<bool> DropColumnAsync(string columnName, string tableName);
}

public class TableRepository : ITable
{
    private readonly InMemoryDatabase _database;
    
    public TableRepository(InMemoryDatabase database)
    {
        _database = database;
    }

    public async ValueTask<Table> GetTableAsync(string tableName)
    {
        return await _database Tables .FirstAsync(t => t.Name == tableName);
    }

    public async ValueTask<bool> CreateTableAsync(Table table)
    {
        await _database.Tables.AddAsync(table);
        return true;
    }

    public async ValueTask<bool> DropTableAsync(string tableName)
    {
        var table = await GetTableAsync(tableName);
        if (table != null)
            return await _database.Tables.DeleteAsync(table);
        return false;
    }

    public async ValueTask<Row> AddRowAsync(Row row, string tableName)
    {
        var table = await GetTableAsync(tableName);
        if (table != null)
            return await _database Tables .FirstAsync(t => t.Name == tableName) 
                .AddAsync(row);
        return default;
    }

    public async ValueTask<bool> UpdateRowAsync(Row updatedRow, string tableName)
    {
        var table = await GetTableAsync(tableName);
        if (table != null)
        {
            var row = await _database.Tables
                .First(t => t.Name == tableName)
                .SelectMany(t => t.Rows)
                .FirstOrDefault(r => r.Id == updatedRow.Id);

            if (row != null)
            {
                await _database.Entry(row).UpdateAsync(updatedRow);
                return true;
            }
        }
        return false;
    }

    public async ValueTask<bool> DeleteRowAsync(int id, string tableName)
    {
        var table = await GetTableAsync(tableName);
        if (table != null)
        {
            var row = await _database Tables 
                .First(t => t.Name == tableName) 
                .SelectMany(t => t.Rows)
                .FirstOrDefault(r => r.Id == id);

            if (row != null)
            {
                await _database.Entry(row).DeleteAsync();
                return true;
            }
        }
        return false;
    }
}

public class InMemoryDatabase : DbContext
{
    public override ValueTask<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default)
        where T : class
    {
        return base.AddAsync(entity);
    }

    public override ValueTask<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        where T : class
    {
        return base.DeleteAsync(entity);
    }

    public override ValueTask<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        where T : class
    {
        return base.UpdateAsync(entity);
    }
}