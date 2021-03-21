using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("FarmType")]
    public class FarmCategory
    {
        public Guid FarmId { get; set; }
        public string Category { get; set; }
    }
}
