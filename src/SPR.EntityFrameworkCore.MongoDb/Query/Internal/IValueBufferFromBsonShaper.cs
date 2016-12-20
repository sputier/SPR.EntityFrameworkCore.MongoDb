using Microsoft.EntityFrameworkCore.Storage;

namespace SPR.EntityFrameworkCore.MongoDb.Query.Internal
{
    public interface IValueBufferFromBsonShaper
    {
        ValueBuffer Shape(ValueBuffer buffer);
    }
}