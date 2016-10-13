using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SPR.EntityFrameworkCore.MongoDb.Storage;
using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions
{
    public class MongoDbConventionSetBuilder : IConventionSetBuilder
    {
        private IMongoDbTypeMapper _typeMapper;

        public MongoDbConventionSetBuilder([NotNull] IMongoDbTypeMapper typeMapper)
        {
            this._typeMapper = typeMapper;
        }

        public ConventionSet AddConventions(ConventionSet conventionSet)
        {
            MongoDbPropertyDiscoveryConvention propertyDiscoveryConvention = new MongoDbPropertyDiscoveryConvention(_typeMapper);

            ReplaceConvention(conventionSet.EntityTypeAddedConventions, (PropertyDiscoveryConvention)propertyDiscoveryConvention);

            //conventionSet.EntityTypeAddedConventions.Add(inversePropertyAttributeConvention);
            //conventionSet.EntityTypeAddedConventions.Add(relationshipDiscoveryConvention);
            RemoveConvention<IEntityTypeConvention, InversePropertyAttributeConvention>(conventionSet.EntityTypeAddedConventions);
            RemoveConvention<IEntityTypeConvention, RelationshipDiscoveryConvention>(conventionSet.EntityTypeAddedConventions);

            //conventionSet.BaseEntityTypeSetConventions.Add(relationshipDiscoveryConvention);
            RemoveConvention<IBaseTypeConvention, RelationshipDiscoveryConvention>(conventionSet.BaseEntityTypeSetConventions);

            //conventionSet.EntityTypeMemberIgnoredConventions.Add(relationshipDiscoveryConvention);
            RemoveConvention<IEntityTypeMemberIgnoredConvention, RelationshipDiscoveryConvention>(conventionSet.EntityTypeMemberIgnoredConventions);

            //conventionSet.NavigationAddedConventions.Add(relationshipDiscoveryConvention);
            RemoveConvention<INavigationConvention, RelationshipDiscoveryConvention>(conventionSet.NavigationAddedConventions);

            //conventionSet.NavigationRemovedConventions.Add(relationshipDiscoveryConvention);
            RemoveConvention<INavigationRemovedConvention, RelationshipDiscoveryConvention>(conventionSet.NavigationRemovedConventions);

            //conventionSet.ModelBuiltConventions.Add(new PropertyMappingValidationConvention());
            ReplaceConvention(conventionSet.ModelBuiltConventions, (PropertyMappingValidationConvention)new MongoDbPropertyMappingValidationConvention(_typeMapper));


            return conventionSet;
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        protected virtual void ReplaceConvention<T1, T2>([NotNull] IList<T1> conventionsList, [NotNull] T2 newConvention)
            where T2 : T1
        {
            var oldConvention = conventionsList.OfType<T2>().FirstOrDefault();
            if (oldConvention == null)
            {
                return;
            }
            var index = conventionsList.IndexOf(oldConvention);
            conventionsList.RemoveAt(index);
            conventionsList.Insert(index, newConvention);
        }

        protected virtual void RemoveConvention<T1, T2>([NotNull] IList<T1> conventionsList)
           where T2 : T1
        {
            var oldConvention = conventionsList.OfType<T2>().FirstOrDefault();
            if (oldConvention == null)
            {
                return;
            }
            var index = conventionsList.IndexOf(oldConvention);
            conventionsList.RemoveAt(index);
        }
    }
}
