public class XBaseField
{
    public string FieldName { get; }
    public Type FieldType { get; }

    public XBaseField(string fieldName, Type fieldType)
    {
        FieldName = fieldName;
        FieldType = fieldType;
    }
}