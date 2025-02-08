using System;
using System.IO;

namespace XBaseLibrary
{
    public record XBaseRecord(string RecordId, string Field1, string Field2)
    {
        public static readonly string FilePath = "xbase_records.dat";

        // Method to write a record to the file system
        public void WriteToFile()
        {
            using (var writer = new StreamWriter(FilePath, true))
            {
                var line = $"{RecordId},{Field1},{Field2}";
                writer.WriteLine(line);
            }
        }

        // Static method to read all records from the file system
        public static XBaseRecord[] ReadAllRecords()
        {
            if (!File.Exists(FilePath)) return Array.Empty<XBaseRecord>();

            var lines = File.ReadAllLines(FilePath);
            var records = new XBaseRecord[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length == 3)
                {
                    records[i] = new XBaseRecord(parts[0], parts[1], parts[2]);
                }
            }

            return records;
        }
    }
}