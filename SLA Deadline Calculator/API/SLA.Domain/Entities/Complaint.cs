
using System.ComponentModel.DataAnnotations;

namespace SLA.Domain;

public class Complaint : BaseEntity
{
    [Required]
    [EnumDataType(typeof(PriorityType))]
    public PriorityType Priority { get; private set; }

    [Required]
    public DateTime CapturedAt { get; private set; }

    public DateTime? ResolutionDeadline { get; private set; }

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

