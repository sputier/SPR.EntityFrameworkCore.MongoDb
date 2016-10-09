using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure.Internal
{
    public class MongoDbModelSource : ModelSource
    {
        public MongoDbModelSource(/*[NotNullAttribute]*/ IDbSetFinder setFinder, 
                                  /*[NotNullAttribute]*/ ICoreConventionSetBuilder coreConventionSetBuilder,
                                  /*[NotNullAttribute]*/ IModelCustomizer modelCustomizer, 
                                  /*[NotNullAttribute]*/ IModelCacheKeyFactory modelCacheKeyFactory) 
            : base(setFinder, coreConventionSetBuilder, modelCustomizer, modelCacheKeyFactory)
        {
        }
    }
}
