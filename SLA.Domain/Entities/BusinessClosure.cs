
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
}
