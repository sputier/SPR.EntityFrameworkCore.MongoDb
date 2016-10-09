using System;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SPR.EntityFrameworkCore.MongoDb.Infrastructure
{
    public class MongoDbOptionsExtension : IDbContextOptionsExtension
    {
        private string _connectionString;
        //private DbConnection _connection;
        private int? _commandTimeout;
        private int? _maxBatchSize;
        private bool _useRelationalNulls;
        private string _migrationsAssembly;
        private string _migrationsHistoryTableName;
        private string _migrationsHistoryTableSchema;
        //private Func<ExecutionStrategyContext, IExecutionStrategy> _executionStrategyFactory;

        public MongoDbOptionsExtension()
        {
        }

        // NB: When adding new options, make sure to update the copy ctor below.

        public MongoDbOptionsExtension(/*[NotNull]*/ MongoDbOptionsExtension copyFrom)
        {
            //Check.NotNull(copyFrom, nameof(copyFrom));

            _connectionString = copyFrom._connectionString;
            //_connection = copyFrom._connection;
            _commandTimeout = copyFrom._commandTimeout;
            _maxBatchSize = copyFrom._maxBatchSize;
            _useRelationalNulls = copyFrom._useRelationalNulls;
            _migrationsAssembly = copyFrom._migrationsAssembly;
            _migrationsHistoryTableName = copyFrom._migrationsHistoryTableName;
            _migrationsHistoryTableSchema = copyFrom._migrationsHistoryTableSchema;
            //_executionStrategyFactory = copyFrom._executionStrategyFactory;
        }

        public virtual string ConnectionString
        {
            get { return _connectionString; }
            //[param: NotNull]
            set
            {
                //Check.NotEmpty(value, nameof(value));

                _connectionString = value;
            }
        }

        //public virtual DbConnection Connection
        //{
        //    get { return _connection; }
        //    //[param: NotNull]
        //    set
        //    {
        //        //Check.NotNull(value, nameof(value));

        //        _connection = value;
        //    }
        //}

        public virtual int? CommandTimeout
        {
            get { return _commandTimeout; }
            //[param: CanBeNull]
            set
            {
                if (value.HasValue && (value <= 0))
                {
                    throw new InvalidOperationException(/*RelationalStrings.InvalidCommandTimeout*/"Invalid command timeout");
                }

                _commandTimeout = value;
            }
        }

        public virtual int? MaxBatchSize
        {
            get { return _maxBatchSize; }
            //[param: CanBeNull]
            set
            {
                if (value.HasValue
                    && (value <= 0))
                {
                    throw new InvalidOperationException(/*RelationalStrings.InvalidMaxBatchSize*/"Invalid max batch size");
                }

                _maxBatchSize = value;
            }
        }

        public virtual bool UseRelationalNulls
        {
            get { return _useRelationalNulls; }
            set { _useRelationalNulls = value; }
        }

        public virtual string MigrationsAssembly
        {
            get { return _migrationsAssembly; }
            //[param: CanBeNull]
            set { _migrationsAssembly = value; }
        }

        public virtual string MigrationsHistoryTableName
        {
            get { return _migrationsHistoryTableName; }
            //[param: CanBeNull]
            set { _migrationsHistoryTableName = value; }
        }

        public virtual string MigrationsHistoryTableSchema
        {
            get { return _migrationsHistoryTableSchema; }
            //[param: CanBeNull]
            set { _migrationsHistoryTableSchema = value; }
        }

        //public virtual Func<ExecutionStrategyContext, IExecutionStrategy> ExecutionStrategyFactory
        //{
        //    get { return _executionStrategyFactory; }
        //    //[param: CanBeNull]
        //    set { _executionStrategyFactory = value; }
        //}

        public void ApplyServices(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        //public abstract void ApplyServices(IServiceCollection services);
    }
}
