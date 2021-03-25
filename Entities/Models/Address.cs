using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [ForeignKey(nameof(Farm))]
        public Guid FarmId { get; set; }
        public FarmCategory Farm { get; set; }
    }
}
