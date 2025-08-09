using System.ComponentModel.DataAnnotations;

namespace SLA.Domain;

public class WorkingHour : BaseEntity
{
    [Required]
    [EnumDataType(typeof(DayOfWeek))]
    public DayOfWeek DayOfWeek { get; private set; }

    [Required]
    public TimeSpan StartTime { get; private set; }

    [Required]
    public TimeSpan EndTime { get; private set; }

    public static WorkingHour CreateNew() => new();

    public WorkingHour SetDayOfWeek(DayOfWeek dayOfWeek)
    {
        DayOfWeek = dayOfWeek;
        return this;
    }

    public WorkingHour SetStartTime(TimeSpan startTime)
    {
        StartTime = startTime;
        return this;
    }

    public WorkingHour SetEndTime(TimeSpan endTime)
    {
        EndTime = endTime;
        return this;
    }
}
