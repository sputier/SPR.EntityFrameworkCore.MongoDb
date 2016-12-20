using System;
using System.Collections.Generic;
using System.Linq;

namespace SPR.EntityFrameworkCore.MongoDb.Storage
{
    public class BsonCommandBuilder : IBsonCommandBuilder
    {
        private string _collectionName;
        private Type _collectionEntityType;

        private List<string> _fieldNames = new List<string>();


        public void AddCollection(string name, Type collectionEntityType)
        {
            _collectionName = name;
            _collectionEntityType = collectionEntityType;
        }

        public void AddField(string name)
        {
            _fieldNames.Add(name);
        }

        public IMongoDbFindCommand Build()
        {
            return new MongoDbFindCommand(_collectionName, _collectionEntityType, BuildProjectionBson(_fieldNames));
        }

        private string BuildProjectionBson(List<string> fieldNames)
            => "{" + string.Join(", ", fieldNames.Select(name => $"\"{name}\" : \"1\"")) + "}";
    }
}
