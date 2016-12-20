using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public class MongoDbModelAnnotations : IMongoDbModelAnnotations
    {
        private readonly MongoDbFullAnnotationsNames _fullAnnotationNames;

        public MongoDbModelAnnotations([NotNull] IModel model,
            [CanBeNull] MongoDbFullAnnotationsNames fullAnnotationNames)
        {
            Annotations = new MongoDbAnnotations(model);
            _fullAnnotationNames = fullAnnotationNames;
        }

        private MongoDbAnnotations Annotations { get; }
        private IModel Model => (IModel)Annotations.Metadata;

        public string DatabaseName
        {
            get
            {
                return (string)Annotations.GetAnnotation(
                    MongoDbFullAnnotationsNames.Instance.DatabaseName);
            }
            [param: CanBeNull]
            set { SetDatabaseName(value); }
        }

        private bool SetDatabaseName([CanBeNull] string value)
             => Annotations.SetAnnotation(
                 _fullAnnotationNames?.DatabaseName,
                 Check.NullButNotEmpty(value, nameof(value)));
    }

}
