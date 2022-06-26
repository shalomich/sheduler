using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model
{
    public class Post : IEntity
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
}
