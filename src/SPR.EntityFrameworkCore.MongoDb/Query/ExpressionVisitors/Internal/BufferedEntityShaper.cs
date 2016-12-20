using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Query.ExpressionVisitors.Internal
{
    public class BufferedEntityShaper<TEntity> : Shaper, IShaper<TEntity>
            where TEntity : class
    {
        public BufferedEntityShaper(
            [NotNull] string entityType,
            bool trackingQuery,
            [NotNull] IKey key,
            [NotNull] Func<ValueBuffer, object> materializer)
        {
            Check.NotNull(entityType, nameof(entityType));
            Check.NotNull(key, nameof(key));
            Check.NotNull(materializer, nameof(materializer));

            EntityType = entityType;
            IsTrackingQuery = trackingQuery;
            Key = key;
            Materializer = materializer;
        }

        protected virtual string EntityType { get; }

        protected virtual bool IsTrackingQuery { get; }

        protected virtual IKey Key { get; }

        protected virtual Func<ValueBuffer, object> Materializer { get; }

        public override Type Type => typeof(TEntity);

        public virtual TEntity Shape([NotNull] QueryContext queryContext, [NotNull] ValueBuffer valueBuffer)
        {
            Check.NotNull(queryContext, nameof(queryContext));
            Check.NotNull(valueBuffer, nameof(valueBuffer));

            var entity
                = (TEntity)queryContext.QueryBuffer
                    .GetEntity(
                        Key,
                        new EntityLoadInfo(valueBuffer, Materializer),
                        queryStateManager: IsTrackingQuery,
                        throwOnNullKey: true);

            return entity;
        }

        public override string ToString() => "BufferedEntityShaper<" + typeof(TEntity).Name + ">";
    }
}
