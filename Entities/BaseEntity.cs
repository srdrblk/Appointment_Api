using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntity
    {
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        protected BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime CreatedDate
        {
            get => DateTime.SpecifyKind(_createdDate, DateTimeKind.Utc);
            private set => _createdDate = value;
        }
        public DateTime ModifiedDate
        {
            get => DateTime.SpecifyKind(_modifiedDate, DateTimeKind.Utc);
            private set => _createdDate = value;
        }
    }
}
