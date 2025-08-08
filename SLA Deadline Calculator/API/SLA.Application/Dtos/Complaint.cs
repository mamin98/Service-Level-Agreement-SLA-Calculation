
using SLA.Domain;

namespace SLA.Application;

public record ComplaintRequestDto(PriorityType Priority, DateTime CaptureDateTime)
{
    public Complaint ToEntity()        
    {
        return Complaint.CreateNew()
            .SetPriority(Priority)
            .SetCapturedAt(CaptureDateTime);
    }
};

public record ComplaintResponseDto(DateTime ResolutionDeadline);