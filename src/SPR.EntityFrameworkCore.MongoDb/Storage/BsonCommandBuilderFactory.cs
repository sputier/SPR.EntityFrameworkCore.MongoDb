namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class BsonCommandBuilderFactory : IBsonCommandBuilderFactory
    {
        public IBsonCommandBuilder Create()
            => new BsonCommandBuilder();
    }
}
