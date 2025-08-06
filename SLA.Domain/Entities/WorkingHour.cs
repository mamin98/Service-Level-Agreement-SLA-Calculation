using System.ComponentModel.DataAnnotations;

namespace SLA.Domain;

public class WorkingHour : BaseEntity
{
    [Required]
    [EnumDataType(typeof(DayOfWeek))]
    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }
}