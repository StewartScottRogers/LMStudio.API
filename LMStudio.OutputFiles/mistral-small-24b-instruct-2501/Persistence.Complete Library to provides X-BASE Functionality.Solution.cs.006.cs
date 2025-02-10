var records = recordService.QueryRecords("SELECT * FROM records");
   foreach (var record in records)
   {
       Console.WriteLine($"{record.Id}, {record.FieldOne}, {record.FieldTwo}");
   }