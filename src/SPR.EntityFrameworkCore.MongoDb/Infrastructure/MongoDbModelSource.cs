using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure
{
    public class MongoDbModelSource : ModelSource
    {
        public MongoDbModelSource([NotNull] IDbSetFinder setFinder, 
                                  [NotNull] ICoreConventionSetBuilder coreConventionSetBuilder, 
                                  [NotNull] IModelCustomizer modelCustomizer, 
                                  [NotNull] IModelCacheKeyFactory modelCacheKeyFactory)
            : base(setFinder, coreConventionSetBuilder, modelCustomizer, modelCacheKeyFactory)
        {
        }
    }
}
