using System.ComponentModel.DataAnnotations;

namespace SLA.Domain;

public class BusinessClosure : BaseEntity
{
    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [MaxLength(250)]
    public string? Reason { get; set; }

    public static BusinessClosure CreateNew() => new();

    public BusinessClosure SetStartTime(DateTime startTime)
    {
        StartTime = startTime;
        return this;
    }

    public BusinessClosure SetEndTime(DateTime endTime)
    {
        EndTime = endTime;
        return this;
    }

    public BusinessClosure SetReason(string? reason)
    {
        Reason = reason;
        return this;
    }
}
