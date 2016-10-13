using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using SPR.EntityFrameworkCore.MongoDb.Storage;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata.Conventions.Internal
{
    public class MongoDbPropertyMappingValidationConvention : PropertyMappingValidationConvention
    {
        private IMongoDbTypeMapper _typeMapper;

        public MongoDbPropertyMappingValidationConvention(IMongoDbTypeMapper typeMapper)
        {
            this._typeMapper = typeMapper;
        }

        public override bool IsMappedPrimitiveProperty([NotNull] Type clrType)
        {
            return this._typeMapper.IsTypeMapped(clrType);
        }
    }
}
