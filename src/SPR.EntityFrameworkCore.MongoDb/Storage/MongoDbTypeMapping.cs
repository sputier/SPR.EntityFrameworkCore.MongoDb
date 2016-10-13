using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class MongoDbTypeMapping
    {
        /// <summary>
        ///     Gets the mapping to be used when the only piece of information is that there is a null value.
        /// </summary>
        public static readonly MongoDbTypeMapping NullMapping = new MongoDbTypeMapping("null");

        /// <summary>
        ///     Initializes a new instance of the <see cref="MongoDbTypeMapping" /> class.
        /// </summary>
        /// <param name="storeType"> The name of the database type. </param>
        /// <param name="clrType"> The .NET type. </param>
        public MongoDbTypeMapping(
            [NotNull] string storeType,
            [NotNull] Type clrType)
            : this(storeType)
        {
            Check.NotNull(clrType, nameof(clrType));

            ClrType = clrType;
        }

        private MongoDbTypeMapping([NotNull] string storeType)
        {
            Check.NotEmpty(storeType, nameof(storeType));

            StoreType = storeType;
        }

        /// <summary>
        ///     Creates a copy of this mapping.
        /// </summary>
        /// <param name="storeType"> The name of the database type. </param>
        /// <returns> The newly created mapping. </returns>
        public virtual MongoDbTypeMapping CreateCopy([NotNull] string storeType)
            => new MongoDbTypeMapping(storeType, ClrType);

        /// <summary>
        ///     Gets the name of the database type.
        /// </summary>
        public virtual string StoreType { get; }

        /// <summary>
        ///     Gets the .NET type.
        /// </summary>
        public virtual Type ClrType { get; }
    }
}
