using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCom.Api
{
    public class ProductType
    {
        public virtual int Id { get; set; }

        public virtual string Initials { get; set; }

        public virtual string Description { get; set; }
    }
}
