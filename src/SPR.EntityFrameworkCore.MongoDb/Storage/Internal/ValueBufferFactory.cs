using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Bson;
using SPR.EntityFrameworkCore.MongoDb.Query.Internal;
using System;

namespace SPR.EntityFrameworkCore.MongoDb.Storage.Internal
{
    public class ValueBufferFactory : IValueBufferFactory
    {
        private readonly Action<object[]> _processValuesAction;

        public ValueBufferFactory([CanBeNull] Action<object[]> processValuesAction)
        {
            _processValuesAction = processValuesAction;
        }

        public virtual ValueBuffer Create(BsonDocument recordData, IValueBufferFromBsonShaper valueBufferShaper) /* object*/
        {
            var fieldCount = recordData.ElementCount;

            if (fieldCount == 0)
            {
                return ValueBuffer.Empty;
            }

            var values = new object[fieldCount];

            _processValuesAction?.Invoke(values);

            for (var i = 0; i < fieldCount; i++)
            {
                values[i] = recordData[i];
            }

            var idx = 0;
            foreach (var bsonElement in recordData)
            {
                values[idx] = bsonElement;
                idx++;
            }

            return valueBufferShaper.Shape(new ValueBuffer(values));
        }
    }
}
