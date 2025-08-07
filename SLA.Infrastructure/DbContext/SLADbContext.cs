using Microsoft.EntityFrameworkCore;
using SLA.Domain;

namespace SLA.Infrastructure;

public class SLADbContext : DbContext
{
    public SLADbContext(DbContextOptions<SLADbContext> options) : base(options) { }

    public DbSet<Complaint> Complaints { get; set; }
    public DbSet<WorkingHour> WorkingHours { get; set; }
    public DbSet<BusinessClosure> BusinessClosures { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.Property(c => c.Priority);
            entity.Property(c => c.CapturedAt);
            entity.Property(c => c.ResolutionDeadline).IsRequired(false);
        });

        modelBuilder.Entity<WorkingHour>(entity =>
        {
            entity.Property(w => w.DayOfWeek);
            entity.Property(w => w.StartTime);
            entity.Property(w => w.EndTime);
        });

        modelBuilder.Entity<BusinessClosure>(entity =>
        {
            entity.Property(b => b.StartTime);
            entity.Property(b => b.EndTime);
            entity.Property(b => b.Reason).HasMaxLength(250);
        });
    }


}
