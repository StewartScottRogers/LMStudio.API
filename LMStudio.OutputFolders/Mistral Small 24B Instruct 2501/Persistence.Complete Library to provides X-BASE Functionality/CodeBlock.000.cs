using System;
using System.Collections.Generic;

namespace XBaseLibrary.Models
{
    public record XBaseRecordDataTuple(int RecordId, Dictionary<string, object> Fields)
    {
        // Constructor and methods can be added if needed.
    }

    public class XBaseRecord
    {
        private readonly int RecordId;
        private readonly Dictionary<string, object> Fields;

        public XBaseRecord(int recordId, Dictionary<string, object> fields)
        {
            RecordId = recordId;
            Fields = fields ?? throw new ArgumentNullException(nameof(fields));
        }

        public int GetRecordId() => RecordId;
        public Dictionary<string, object> GetFields() => Fields;

        // Methods to manipulate the record.
    }
}