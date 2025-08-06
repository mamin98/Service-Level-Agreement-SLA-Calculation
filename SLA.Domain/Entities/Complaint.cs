
using System.ComponentModel.DataAnnotations;

namespace SLA.Domain;

public class Complaint : BaseEntity
{
    [Required]
    [EnumDataType(typeof(PriorityType))]
    public PriorityType Priority { get; set; }

    [Required]
    public DateTime CapturedAt { get; set; }

    public DateTime? ResolutionDeadline { get; set; }

    public static Complaint CreateNew() => new();

    public Complaint SetPriority(PriorityType priority)
    {
        Priority = priority;
        return this;
    }
    public Complaint SetCapturedAt(DateTime capturedAt)
    {
        CapturedAt = capturedAt;
        return this;
    }
    public Complaint SetResolutionDeadline(DateTime? resolutionDeadline)
    {
        ResolutionDeadline = resolutionDeadline;
        return this;
    }

}

