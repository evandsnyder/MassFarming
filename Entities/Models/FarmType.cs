using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("FarmType")]
    public class FarmType
    {
        [Key]
        public Guid FarmTypeId { get; set; }
        public string Category { get; set; }
    }
}
