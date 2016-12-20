using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using System;
using System.Linq.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Expressions
{
    public class FieldExpression : Expression
    {
        private readonly IProperty _property;
        private readonly CollectionExpression _collectionExpression;

        public FieldExpression(
            [NotNull] string name,
            [NotNull] IProperty property,
            [NotNull] CollectionExpression collectionExpression)
            : this(name, Check.NotNull(property, nameof(property)).ClrType, collectionExpression)
        {
            _property = property;
        }

        public FieldExpression(
            [NotNull] string name,
            [NotNull] Type type,
            [NotNull] CollectionExpression collectionExpression)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(type, nameof(type));
            Check.NotNull(collectionExpression, nameof(collectionExpression));

            Name = name;
            Type = type;
            _collectionExpression = collectionExpression;
        }

        public virtual CollectionExpression Collection => _collectionExpression;

        public virtual string CollectionName => _collectionExpression.Name;

#pragma warning disable 108

        public virtual IProperty Property => _property;
#pragma warning restore 108

        public virtual string Name { get; }

        public override ExpressionType NodeType => ExpressionType.Extension;

        public override Type Type { get; }

        protected override Expression VisitChildren(ExpressionVisitor visitor) => this;

        private bool Equals([NotNull] FieldExpression other)
            => ((_property == null && other._property == null)
                || (_property != null && _property.Equals(other._property)))
               && Type == other.Type
               && _collectionExpression.Equals(other._collectionExpression);

        public override bool Equals([CanBeNull] object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return (obj.GetType() == GetType())
                   && Equals((FieldExpression)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_property.GetHashCode() * 397)
                       ^ _collectionExpression.GetHashCode();
            }
        }

        public override string ToString() => Name;
    }

}
