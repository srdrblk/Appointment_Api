using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Appointment : BaseEntity
    {
        public int UserId { get; set; }


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UsedCount { get; set; }

        public bool IsActive { get; set; }

        public string Detail { get; set; }

        public string WithWho { get; set; }
    }
}
