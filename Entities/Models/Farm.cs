using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Farm")]
    public class Farm
    {
        [Key]
        public Guid FarmId { get; set; }
        public string FarmName { get; set; }
        public string FarmAddress { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int DoesDelivery { get; set; }
        public string WebsiteUrl { get; set; }
        public string ContactEmail { get; set; }

        public ICollection<FarmCategory> Categories { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
