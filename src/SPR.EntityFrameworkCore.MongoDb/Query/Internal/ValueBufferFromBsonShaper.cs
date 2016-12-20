using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Query.Expressions;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public class ValueBufferFromBsonShaper : IValueBufferFromBsonShaper
    {
        private readonly FindExpression _findExpression;

        public ValueBufferFromBsonShaper([NotNull] FindExpression findExpression)
        {
            Check.NotNull(findExpression, nameof(findExpression));
            
            _findExpression = findExpression;
        }

        public ValueBuffer Shape(ValueBuffer buffer)
        {
            return ConvertBsonValuesToClrTypes(ReorderFields(buffer));
        }

        private ValueBuffer ReorderFields(ValueBuffer buffer)
        {
            object[] orderedValues = new object[buffer.Count];

            for (int i = 0; i < _findExpression.Projection.Count; i++)
            {
                for (int j = 0; j < buffer.Count; j++)
                {
                    var bsonVal = (MongoDB.Bson.BsonElement)buffer[j];
                    if (bsonVal.Name == _findExpression.Projection[i].Name)
                    {
                        orderedValues[i] = bsonVal.Value;
                        break;
                    }
                }
            }

            return new ValueBuffer(orderedValues);
        }

        private ValueBuffer ConvertBsonValuesToClrTypes(ValueBuffer buffer)
        {
            for (int i = 0; i < buffer.Count; i++)
            {
                buffer[i] = ConvertToBaseClrType(buffer[i]);
            }
            return buffer;
        }

        private object ConvertToBaseClrType(object value)
        {
            if (value is MongoDB.Bson.BsonObjectId)
                return ((MongoDB.Bson.BsonObjectId)value).ToString();
            if (value is MongoDB.Bson.BsonValue)
                return MongoDB.Bson.BsonTypeMapper.MapToDotNetValue((MongoDB.Bson.BsonValue)value);
            return value;
        }
    }
}
