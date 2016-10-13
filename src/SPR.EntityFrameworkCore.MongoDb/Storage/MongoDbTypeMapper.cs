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
        private readonly MongoDbTypeMapping _double
               = new MongoDbTypeMapping("double", typeof(double));

        private readonly MongoDbTypeMapping _string
            = new MongoDbTypeMapping("string", typeof(string));

        private readonly MongoDbTypeMapping _object
            = new MongoDbTypeMapping("object", typeof(object));

        private readonly MongoDbTypeMapping _binaryData
            = new MongoDbTypeMapping("binData", typeof(byte[]));

        private readonly MongoDbTypeMapping _objectId
            = new MongoDbTypeMapping("objectId", typeof(ObjectId));

        private readonly MongoDbTypeMapping _boolean
            = new MongoDbTypeMapping("bool", typeof(bool));

        private readonly MongoDbTypeMapping _date
            = new MongoDbTypeMapping("date", typeof(DateTime));

        private readonly MongoDbTypeMapping _int32
            = new MongoDbTypeMapping("int", typeof(int));

        private readonly MongoDbTypeMapping _int64
            = new MongoDbTypeMapping("long", typeof(long));

        private readonly Dictionary<string, MongoDbTypeMapping> _storeTypeMappings;
        private readonly Dictionary<Type, MongoDbTypeMapping> _clrTypeMappings;
        private readonly HashSet<string> _disallowedMappings;

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public MongoDbTypeMapper()
        {
            _storeTypeMappings
                = new Dictionary<string, MongoDbTypeMapping>(StringComparer.OrdinalIgnoreCase)
                {
                    { "double", _double },
                    { "string", _string },
                    { "object", _object },
                    { "binData", _binaryData },
                    { "objectId", _objectId },
                    { "date", _date },
                    { "int", _int32 },
                    { "long", _int64 }
                };

            _clrTypeMappings
                = new Dictionary<Type, MongoDbTypeMapping>
                {
                     { typeof(double), _double },
                    { typeof(string), _string },
                    { typeof(object), _object },
                    { typeof(byte[]), _binaryData },
                    { typeof(ObjectId), _objectId },
                    { typeof(bool), _boolean },
                    { typeof(DateTime), _date },
                    { typeof(int), _int32 },
                    { typeof(long), _int64 }
                };

            // These are disallowed only if specified without any kind of length specified in parenthesis.
            // This is because we don't try to make a new type from this string and any max length value
            // specified in the model, which means use of these strings is almost certainly an error, and
            // if it is not an error, then using, for example, varbinary(1) will work instead.
            _disallowedMappings
                = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "array",
                    "null",
                    "regex",
                    "javascript",
                    "javascriptWithScope",
                    "timestamp",
                    "minKey",
                    "maxKey"
                };
        }

        public MongoDbTypeMapping FindMapping([NotNull] string storeType)
        {
            throw new NotImplementedException();
        }

        public MongoDbTypeMapping FindMapping([NotNull] Type clrType)
        {
            Check.NotNull(clrType, nameof(clrType));

            clrType = clrType.UnwrapNullableType().UnwrapEnumType();

            MongoDbTypeMapping mapping;
            return _clrTypeMappings.TryGetValue(clrType, out mapping) ? mapping : null;
        }

        public MongoDbTypeMapping FindMapping([NotNull] IProperty property)
        {
            throw new NotImplementedException();
        }

        public void ValidateTypeName([NotNull] string storeType)
        {
            if (_disallowedMappings.Contains(storeType))
            {
                throw new ArgumentException($"Data type '{storeType}' is not supported");
            }
        }


        /// <summary>
        ///     Gets the database type for a given object, throwing if no mapping is found.
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
