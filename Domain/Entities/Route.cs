using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.Entities
{
    public class Route : Entity
    {
        public Guid OriginLocationId { get; set; }
        public Guid DestinyLocationId { get; set; }
        public double Cost { get; set; }

        public virtual required Location OriginLocation { get; set; }
        public virtual required Location DestinyLocation { get; set; }
    }
}
