using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class IsAForCreationDto
    {
        public Guid FarmId { get; set; }
        public Guid FarmTypeId { get; set; }
    }
}
