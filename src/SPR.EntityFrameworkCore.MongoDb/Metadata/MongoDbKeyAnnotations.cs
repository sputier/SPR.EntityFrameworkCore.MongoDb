using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.EntityFrameworkCore.Metadata;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public class MongoDbKeyAnnotations : IMongoDbKeyAnnotations
    {
        private const string DefaultPrimaryKeyNamePrefix = "PK";
        private const string DefaultAlternateKeyNamePrefix = "AK";

        private readonly MongoDbFullAnnotationsNames _fullAnnotationNames;

        public MongoDbKeyAnnotations([NotNull] IKey key,
            [CanBeNull] MongoDbFullAnnotationsNames fullAnnotationNames)
        {
            Annotations = new MongoDbAnnotations(key);
            _fullAnnotationNames = fullAnnotationNames;
        }

        private MongoDbAnnotations Annotations { get; }
        private IKey Key => (IKey)Annotations.Metadata;

        private IMongoDbEntityTypeAnnotations GetAnnotations([NotNull] IEntityType entityType)
           => new MongoDbEntityTypeAnnotations(entityType, _fullAnnotationNames);

        private IMongoDbPropertyAnnotations GetAnnotations([NotNull] IProperty property)
           => new MongoDbPropertyAnnotations(property, _fullAnnotationNames);

        public string Name
        {
            get
            {
                return (string)Annotations.GetAnnotation(MongoDbFullAnnotationsNames.Instance.Name)
                       ?? GetDefaultName();
            }
            [param: CanBeNull]
            set { SetName(value); }
        }

        private bool SetName([CanBeNull] string value)
           => Annotations.SetAnnotation(
               _fullAnnotationNames?.Name,
               Check.NullButNotEmpty(value, nameof(value)));

        private string GetDefaultName()
        {
            return GetDefaultKeyName(
                GetAnnotations(Key.DeclaringEntityType).CollectionName,
                Key.IsPrimaryKey(),
                Key.Properties.Select(p => GetAnnotations(p).FieldName));
        }

        public static string GetDefaultKeyName(
            [NotNull] string tableName, bool primaryKey, [NotNull] IEnumerable<string> propertyNames)
        {
            Check.NotEmpty(tableName, nameof(tableName));
            Check.NotNull(propertyNames, nameof(propertyNames));

            var builder = new StringBuilder();

            if (primaryKey)
            {
                builder
                    .Append(DefaultPrimaryKeyNamePrefix)
                    .Append("_")
                    .Append(tableName);
            }
            else
            {
                builder
                    .Append(DefaultAlternateKeyNamePrefix)
                    .Append("_")
                    .Append(tableName)
                    .Append("_")
                    .AppendJoin(propertyNames, "_");
            }

            return builder.ToString();
        }
    }
}
