using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class FarmForUpdateDto
    {
        [Required]
        public Guid FarmId { get; set; }
        [Required(ErrorMessage = "Farm Name is required")]
        public string FarmName { get; set; }
        [Required(ErrorMessage = "Farm Owner is required")]
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public bool DoesDelivery { get; set; }
        public string WebsiteUrl { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string ContactEmail { get; set; }

        public bool IsContactable { get; set; }
        public bool IsActive { get; set; }

        public AddressForCreationDto Address { get; set; }

        public ICollection<SchedulesForCreationDto> Schedules { get; set; }

        public ICollection<IsAForCreationDto> categories { get; set; }
    }
}
