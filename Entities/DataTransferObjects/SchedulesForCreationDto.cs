namespace Entities.DataTransferObjects
{
    public class SchedulesForCreationDto
    {
        public int DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}