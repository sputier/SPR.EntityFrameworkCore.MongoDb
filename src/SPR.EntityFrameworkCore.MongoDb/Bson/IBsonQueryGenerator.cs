using SPR.EntityFrameworkCore.MongoDb.Storage;

namespace SPR.EntityFrameworkCore.MongoDb.Bson
{
    public interface IBsonQueryGenerator
    {
        IMongoDbFindCommand GenerateBsonCommand();

        IValueBufferFactory CreateValueBufferFactory(IValueBufferFactoryFactory valueBufferFactoryFactory);
    }
}