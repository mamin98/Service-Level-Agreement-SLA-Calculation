using SLA.Domain;

namespace SLA.Application;
public class CalculateSlaService : ICalculateSlaService
{
    private readonly IRepository<WorkingHour> _workingHourRepo;
    private readonly IRepository<BusinessClosure> _closureRepo;

    public CalculateSlaService(
        IRepository<WorkingHour> workingHourRepo,
        IRepository<BusinessClosure> closureRepo)
    {
        _workingHourRepo = workingHourRepo;
        _closureRepo = closureRepo;
    }
    public async Task<DateTime> CalculateResolutionDeadlineAsync(PriorityType priority, DateTime captureDateTime, CancellationToken cancellationToken)
    {
        var deadline = captureDateTime;
        int requiredHours = (int)priority;

        var workingHour = await _workingHourRepo.FindAsync(w => w.DayOfWeek == deadline.DayOfWeek, cancellationToken);
      
        var closures = await _closureRepo.GetAsync(cancellationToken);

        int businessHoursCount = 0;

        while (businessHoursCount < requiredHours)
        {
            deadline = deadline.AddHours(1);

            if (closures.Any(c => c.StartTime <= deadline && deadline < c.EndTime))
                continue;

            if (workingHour is not null && deadline.TimeOfDay >= workingHour.StartTime && deadline.TimeOfDay < workingHour.EndTime)
                businessHoursCount++;
        }

        return deadline;
    }
}
