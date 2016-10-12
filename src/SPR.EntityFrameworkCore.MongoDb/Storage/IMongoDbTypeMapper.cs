using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public interface IMongoDbTypeMapper
    {
        /// <summary>
        ///     Gets the relational database type for the given property.
        ///     Returns null if no mapping is found.
        /// </summary>
        /// <param name="property"> The property to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        MongoDbTypeMapping FindMapping([NotNull] IProperty property);

        /// <summary>
        ///     Gets the Mongo Db type for a given .NET type.
        ///     Returns null if no mapping is found.
        /// </summary>
        /// <param name="clrType"> The type to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        MongoDbTypeMapping FindMapping([NotNull] Type clrType);

        /// <summary>
        ///     Gets the mapping that represents the given database type.
        ///     Returns null if no mapping is found.
        /// </summary>
        /// <param name="storeType"> The type to get the mapping for. </param>
        /// <returns> The type mapping to be used. </returns>
        MongoDbTypeMapping FindMapping([NotNull] string storeType);

        /// <summary>
        ///     Ensures that the given type name is a valid type for the database.
        ///     An exception is thrown if it is not a valid type.
        /// </summary>
        /// <param name="storeType"> The type to be validated. </param>
        void ValidateTypeName([NotNull] string storeType);
        
        MongoDbTypeMapping GetMapping([NotNull] Type clrType);
        MongoDbTypeMapping GetMapping([NotNull] string typeName);
        MongoDbTypeMapping GetMapping([NotNull] IProperty property);
        MongoDbTypeMapping GetMappingForValue([CanBeNull] object value);
        bool IsTypeMapped([NotNull] Type clrType);
    }
}
