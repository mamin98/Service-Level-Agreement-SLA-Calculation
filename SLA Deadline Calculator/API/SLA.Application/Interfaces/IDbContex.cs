using Microsoft.EntityFrameworkCore;
using SLA.Domain;

namespace SLA.Application;

public interface IDbContext
{
    DbSet<Complaint> Complaints { get; }
    DbSet<WorkingHour> WorkingHours { get; }
    DbSet<BusinessClosure> BusinessClosures { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
