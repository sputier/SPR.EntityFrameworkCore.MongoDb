namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Internal
{
    public class MongoDbFullAnnotationsNames
    {
        public MongoDbFullAnnotationsNames(string prefix)
        {
            FieldName = prefix + MongoDbAnnotationsNames.FieldName;
            FieldType = prefix + MongoDbAnnotationsNames.FieldType;
            DefaultValue = prefix + MongoDbAnnotationsNames.DefaultValue;
            DatabaseName = prefix + MongoDbAnnotationsNames.DatabaseName;
            CollectionName = prefix + MongoDbAnnotationsNames.CollectionName;
            Name = prefix + MongoDbAnnotationsNames.Name;
        }

        public static MongoDbFullAnnotationsNames Instance { get; } = new MongoDbFullAnnotationsNames(MongoDbAnnotationsNames.Prefix);

        public readonly string FieldName;

        public readonly string FieldType;

        public readonly string DefaultValue;

        public readonly string DatabaseName;

        public readonly string CollectionName;

        public readonly string Name;
    }
}
