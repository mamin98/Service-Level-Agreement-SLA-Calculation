using SLA.Domain;

namespace SLA.Application;

public interface ICalculateSlaService
{
    Task<DateTime> CalculateResolutionDeadlineAsync(
        PriorityType priority,
        DateTime capturedAt,
        CancellationToken cancellationToken
    );
}
