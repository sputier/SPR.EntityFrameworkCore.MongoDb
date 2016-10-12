using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbTypeMapper : IMongoDbTypeMapper
    {
        public MongoDbTypeMapping FindMapping([NotNull] string storeType)
        {
            throw new NotImplementedException();
        }

        public MongoDbTypeMapping FindMapping([NotNull] Type clrType)
        {
            throw new NotImplementedException();
        }

        public MongoDbTypeMapping FindMapping([NotNull] IProperty property)
        {
            throw new NotImplementedException();
        }

        public void ValidateTypeName([NotNull] string storeType)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///     Gets the relational database type for a given object, throwing if no mapping is found.
        /// </summary>
        /// <param name="value"> The object to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        public MongoDbTypeMapping GetMappingForValue([CanBeNull] object value)
            => (value == null)
               || (value == DBNull.Value)
                ? null//MongoDbTypeMapping.NullMapping
                : this.GetMapping(value.GetType());

        /// <summary>
        ///     Gets the database type for a given property, throwing if no mapping is found.
        /// </summary>
        /// <param name="property"> The property to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        public MongoDbTypeMapping GetMapping([NotNull] IProperty property)
        {
            Check.NotNull(property, nameof(property));

            var mapping = this.FindMapping(property);
            if (mapping != null)
            {
                return mapping;
            }

            var entity = property.DeclaringEntityType.ClrType.DisplayName();
            var propertyName = property.Name;
            var clrType = property.ClrType.ShortDisplayName();
            throw new InvalidOperationException($"No mapping to a DB type can be found for property '{entity}.{property}' with the CLR type '{clrType}'.");
        }

        /// <summary>
        ///     Gets the database type for a given .NET type, throwing if no mapping is found.
        /// </summary>
        /// <param name="clrType"> The type to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        public MongoDbTypeMapping GetMapping([NotNull] Type clrType)
        {
            Check.NotNull(clrType, nameof(clrType));

            var mapping = this.FindMapping(clrType);
            if (mapping != null)
            {
                return mapping;
            }

            throw new InvalidOperationException($"No mapping to a relational type can be found for the CLR type '{clrType.ShortDisplayName()}'.");
        }

        /// <summary>
        ///     Gets the mapping that represents the given database type, throwing if no mapping is found.
        /// </summary>
        /// <param name="typeName"> The type to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        public MongoDbTypeMapping GetMapping([NotNull] string typeName)
        {
            Check.NotNull(typeName, nameof(typeName));

            var mapping = this.FindMapping(typeName);
            if (mapping != null)
            {
                return mapping;
            }

            throw new InvalidOperationException($"No mapping to a relational type can be found for the CLR type '{typeName}'.");
        }

        /// <summary>
        ///     Gets a value indicating whether the given .NET type is mapped.
        /// </summary>
        /// <param name="clrType"> The .NET type. </param>
        /// <returns> True if the type can be mapped; otherwise false. </returns>
        public bool IsTypeMapped([NotNull] Type clrType)
        {
            Check.NotNull(clrType, nameof(clrType));

            return this.FindMapping(clrType) != null;
        }





    }
}
