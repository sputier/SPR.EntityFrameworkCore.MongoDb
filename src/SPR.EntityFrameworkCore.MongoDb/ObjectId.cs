using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb
{
    public class ObjectId
    {
        private MongoDB.Bson.ObjectId _bsonObjectId;

        public static implicit operator string([NotNull] ObjectId id)
        {
            Check.NotNull(id, nameof(id));

            return id._bsonObjectId.ToString();
        }

        public static implicit operator ObjectId([NotNull] string id)
        {
            Check.NotNull(id, nameof(id));

            var res = new ObjectId();
            res._bsonObjectId = new MongoDB.Bson.ObjectId(id);

            return res;
        }

        public ObjectId()
        {
            this._bsonObjectId = MongoDB.Bson.ObjectId.Empty;
        }
    }
}
