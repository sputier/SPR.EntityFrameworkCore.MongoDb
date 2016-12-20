using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal
{
    public class MongoDbConventionSetBuilder : IConventionSetBuilder
    {
        public virtual ConventionSet AddConventions(ConventionSet conventionSet)
        {
            var fieldAttributeConvention = new MongoDbFieldAttributeConvention();
            conventionSet.PropertyAddedConventions.Add(fieldAttributeConvention);
            conventionSet.PropertyFieldChangedConventions.Add(fieldAttributeConvention);

            return conventionSet;
        }

        public static ConventionSet Build()
            => new MongoDbConventionSetBuilder()
                .AddConventions(new CoreConventionSetBuilder().CreateConventionSet());
    }
}
