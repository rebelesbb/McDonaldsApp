using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McApp.domain
{
    public class Entity<ID>
    {
        public ID? Id { get; set; }
    }
}
