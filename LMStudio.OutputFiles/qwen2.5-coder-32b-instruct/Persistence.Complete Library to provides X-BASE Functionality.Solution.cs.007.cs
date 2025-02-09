var record = new XBaseRecord { RecordId = "1", Fields = new Dictionary<string, object> { { "Name", "Test" } } };
db.Insert(record, "NewTable");