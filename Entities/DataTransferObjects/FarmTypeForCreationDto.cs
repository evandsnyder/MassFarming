using System;

namespace Entities.DataTransferObjects
{
    public class FarmTypeForCreationDto
    {
        public Guid FarmTypeId { get; set; }
        public string Category { get; set; }
    }
}