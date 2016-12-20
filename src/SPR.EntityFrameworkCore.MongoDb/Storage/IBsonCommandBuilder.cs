using System;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public interface IBsonCommandBuilder
    {
        void AddCollection(string name, Type collectionEntityType);

        void AddField(string name);

        IMongoDbFindCommand Build();
    }
}
