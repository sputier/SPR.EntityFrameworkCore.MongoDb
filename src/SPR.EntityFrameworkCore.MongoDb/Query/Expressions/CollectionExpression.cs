using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using System;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Expressions
{
    public class CollectionExpression : Expression
    {
        public CollectionExpression(
            [NotNull] string collection,
            [NotNull] Type entityType)
        {
            Check.NotEmpty(collection, nameof(collection));
            Check.NotNull(entityType, nameof(entityType));

            Name = collection;
            EntityType = entityType;
        }

        public virtual string Name { get; }

        public virtual Type EntityType { get; }

        public override string ToString() => Name;
    }
}
