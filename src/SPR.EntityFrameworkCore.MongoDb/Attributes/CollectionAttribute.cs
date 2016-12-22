using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR.EntityFrameworkCore.MongoDb.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionAttribute : Attribute
    {
        public CollectionAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
