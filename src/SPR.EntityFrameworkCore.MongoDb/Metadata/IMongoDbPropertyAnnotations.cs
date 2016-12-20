namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public interface IMongoDbPropertyAnnotations
    {
        string FieldName { get; }
        string FieldType { get; }
        object DefaultValue { get; }
    }
}