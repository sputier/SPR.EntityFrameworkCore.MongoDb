namespace Microsoft.EntityFrameworkCore.Infrastructure
{
    /// <summary>
    ///     <para>
    ///         Allows SQLite specific configuration to be performed on <see cref="DbContextOptions" />.
    ///     </para>
    ///     <para>
    ///         Instances of this class are returned from a call to
    ///         <see
    ///             cref="MongoDbContextOptionsBuilderExtensions.UseSqlite(DbContextOptionsBuilder, string, System.Action{SqliteDbContextOptionsBuilder})" />
    ///         and it is not designed to be directly constructed in your application code.
    ///     </para>
    /// </summary>
    public class MongoDbContextOptionsBuilder : DbContextOptionsBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MongoDbContextOptionsBuilder" /> class.
        /// </summary>
        /// <param name="optionsBuilder"> The options builder. </param>
        public MongoDbContextOptionsBuilder(/*[NotNull]*/ DbContextOptionsBuilder optionsBuilder)
            : base(optionsBuilder.Options)
        {
        }
    }
}

