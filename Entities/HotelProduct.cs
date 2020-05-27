using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class HotelProduct : BaseEntity
    {
        public int HotelId { get; set; }

        public int ServiceId { get; set; }

        public int Price { get; set; }
    }
}
