using SLA.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace SLA.Infrastructure;

public class DbSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SLADbContext>();

        if (!context.WorkingHours.Any())
        {
            context.WorkingHours.AddRange(
            [
                 WorkingHour.CreateNew().SetDayOfWeek(DayOfWeek.Monday).SetStartTime(new TimeSpan(9, 0, 0)).SetEndTime(new TimeSpan(17, 0, 0)),
                 WorkingHour.CreateNew().SetDayOfWeek(DayOfWeek.Tuesday).SetStartTime(new TimeSpan(9, 0, 0)).SetEndTime(new TimeSpan(17, 0, 0)),
                 WorkingHour.CreateNew().SetDayOfWeek(DayOfWeek.Wednesday).SetStartTime(new TimeSpan(9, 0, 0)).SetEndTime(new TimeSpan(17, 0, 0)),
                 WorkingHour.CreateNew().SetDayOfWeek(DayOfWeek.Thursday).SetStartTime(new TimeSpan(9, 0, 0)).SetEndTime(new TimeSpan(17, 0, 0)),
                 WorkingHour.CreateNew().SetDayOfWeek(DayOfWeek.Friday).SetStartTime(new TimeSpan(9, 0, 0)).SetEndTime(new TimeSpan(17, 0, 0)),
            ]);
        }

        if (!context.BusinessClosures.Any())
        {
            context.BusinessClosures.AddRange(
            [
                 BusinessClosure.CreateNew().SetStartTime(new DateTime(2025, 1, 1)).SetEndTime(new DateTime(2025, 1, 1, 23, 59, 0)).SetReason("New Year's Day"),
                 BusinessClosure.CreateNew().SetStartTime(new DateTime(2025, 4, 25)).SetEndTime(new DateTime(2025, 4, 25, 23, 59, 0)).SetReason("National Holiday"),
                 BusinessClosure.CreateNew().SetStartTime(new DateTime(2025, 12, 25)).SetEndTime(new DateTime(2025, 12, 25, 23, 59, 0)).SetReason("Christmas Day"),
                 BusinessClosure.CreateNew().SetStartTime(new DateTime(2025, 7, 30, 12, 0, 0)).SetEndTime(new DateTime(2025, 7, 30, 15, 0, 0)).SetReason("Special Event Closure"),
            ]);
        }

        context.SaveChanges();
    }
}
