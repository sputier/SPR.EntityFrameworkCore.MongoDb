using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using SPR.EntityFrameworkCore.MongoDb.Metadata.Internal;
using System;
using System.Globalization;
using System.Reflection;

namespace SPR.EntityFrameworkCore.MongoDb.Metadata
{
    public class MongoDbPropertyAnnotations : IMongoDbPropertyAnnotations
    {
        protected readonly MongoDbFullAnnotationsNames _fullAnnotationNames;

        public MongoDbPropertyAnnotations([NotNull] IProperty property,
            [CanBeNull] MongoDbFullAnnotationsNames providerFullAnnotationNames)
            : this(new MongoDbAnnotations(property), providerFullAnnotationNames)
        {
        }

        protected MongoDbPropertyAnnotations([NotNull] MongoDbAnnotations annotations,
            [CanBeNull] MongoDbFullAnnotationsNames providerFullAnnotationNames)
        {
            Annotations = annotations;
            _fullAnnotationNames = providerFullAnnotationNames;
        }


        protected virtual MongoDbAnnotations Annotations { get; }
        protected virtual IProperty Property => (IProperty)Annotations.Metadata;

        public virtual string FieldName
        {
            get
            {
                return (string)Annotations.GetAnnotation(
                    _fullAnnotationNames?.FieldName)
                       ?? Property.Name;
            }
            [param: CanBeNull]
            set { SetFieldName(value); }
        }

        protected virtual bool SetFieldName([CanBeNull] string value)
            => Annotations.SetAnnotation(
                _fullAnnotationNames?.FieldName,
                Check.NullButNotEmpty(value, nameof(value)));

        public virtual string FieldType
        {
            get
            {
                return (string)Annotations.GetAnnotation(
                    _fullAnnotationNames?.FieldType);
            }
            [param: CanBeNull]
            set { SetFieldType(value); }
        }

        protected virtual bool SetFieldType([CanBeNull] string value)
            => Annotations.SetAnnotation(
                _fullAnnotationNames?.FieldType,
                Check.NullButNotEmpty(value, nameof(value)));

        public virtual object DefaultValue
        {
            get
            {
                return (string)Annotations.GetAnnotation(
                    _fullAnnotationNames?.DefaultValue);
            }
            [param: CanBeNull]
            set { SetDefaultValue(value); }
        }

        protected virtual bool SetDefaultValue([CanBeNull] object value)
        {
            if (value != null)
            {
                var valueType = value.GetType();
                if (Property.ClrType.UnwrapNullableType() != valueType)
                {
                    throw new InvalidOperationException(
                        $@"Cannot set default value '{value}' of type 
                           '{valueType}' on property '{Property.Name}'
                           of type '{Property.ClrType}' in entity type 
                           '{ Property.DeclaringEntityType.DisplayName() }'.");
                }

                if (valueType.GetTypeInfo().IsEnum)
                {
                    value = Convert.ChangeType(value, valueType.UnwrapEnumType(), CultureInfo.InvariantCulture);
                }
            }

            if (!CanSetDefaultValue(value))
            {
                return false;
            }

            if (DefaultValue != value
                && value != null)
            {
                SetDefaultValue(null);
            }

            return Annotations.SetAnnotation(
                _fullAnnotationNames?.DefaultValue,
                value);
        }

        protected virtual bool CanSetDefaultValue([CanBeNull] object value)
        {
            if (!Annotations.CanSetAnnotation(
                _fullAnnotationNames?.DefaultValue,
                value))
            {
                return false;
            }

            return true;
        }
    }

}
