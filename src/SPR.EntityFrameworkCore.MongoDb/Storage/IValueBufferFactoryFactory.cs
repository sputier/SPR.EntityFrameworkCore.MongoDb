using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public interface IValueBufferFactoryFactory
    {
        IValueBufferFactory Create(
            [NotNull] IReadOnlyList<Type> type,
            [CanBeNull] IReadOnlyList<int> indexMap);
    }
}
