namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public interface IBsonCommandBuilderFactory
    {
        IBsonCommandBuilder Create();
    }
}
