using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class FarmDto
    {
        public Guid FarmId { get; set; }
        public string FarmName { get; set; }

        public AddressDto Address { get; set; }
        public ICollection<IsA> Categories { get; set; }
    }
}
