using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using System.Diagnostics;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public class MongoDbAnnotations
    {
        public MongoDbAnnotations([NotNull] IAnnotatable metadata)
        {
            Check.NotNull(metadata, nameof(metadata));

            Metadata = metadata;
        }

        public virtual IAnnotatable Metadata { get; }

        public virtual object GetAnnotation([CanBeNull] string annotationName)
            => annotationName == null ? null : Metadata[annotationName];

        public virtual bool SetAnnotation(
            [CanBeNull] string annotationName,
            [CanBeNull] object value)
        {
            var annotatable = Metadata as IMutableAnnotatable;
            Debug.Assert(annotatable != null);

            annotatable[annotationName] = value;
            return true;
        }

        public virtual bool CanSetAnnotation(
            [NotNull] string annotationName,
            [CanBeNull] object value)
            => true;
    }
}
