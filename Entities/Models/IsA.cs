using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("IsA")]
    public class IsA
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Farm))]
        public Guid FarmId { get; set; }

        [ForeignKey(nameof(FarmType))]
        public Guid FarmTypeId { get; set; }
        public FarmType FarmType { get; set; }
    }
}
