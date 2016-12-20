using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public class MongoDbEntityTypeAnnotations : IMongoDbEntityTypeAnnotations
    {
        private readonly MongoDbFullAnnotationsNames FullAnnotationNames;

        public MongoDbEntityTypeAnnotations(
            [NotNull] IEntityType entityType,
            [CanBeNull] MongoDbFullAnnotationsNames fullAnnotationNames)
        {
            Annotations = new MongoDbAnnotations(entityType);
            FullAnnotationNames = fullAnnotationNames;
        }

        private MongoDbAnnotations Annotations { get; }
        private IEntityType EntityType => (IEntityType)Annotations.Metadata;

        private MongoDbModelAnnotations GetAnnotations([NotNull] IModel model)
            => new MongoDbModelAnnotations(model, FullAnnotationNames);

        private MongoDbEntityTypeAnnotations GetAnnotations([NotNull] IEntityType entityType)
             => new MongoDbEntityTypeAnnotations(entityType, FullAnnotationNames);

        public string CollectionName
        {
            get
            {
                if (EntityType.BaseType != null)
                {
                    var rootType = EntityType.RootType();
                    return GetAnnotations(rootType).CollectionName;
                }

                return (string)Annotations.GetAnnotation(
                    MongoDbFullAnnotationsNames.Instance.CollectionName)
                       ?? EntityType.DisplayName();
            }
            [param: CanBeNull]
            set { SetCollectionName(value); }
        }

        private bool SetCollectionName([CanBeNull] string value)
            => Annotations.SetAnnotation(
                MongoDbFullAnnotationsNames.Instance.CollectionName,
                Check.NullButNotEmpty(value, nameof(value)));
    }
}
