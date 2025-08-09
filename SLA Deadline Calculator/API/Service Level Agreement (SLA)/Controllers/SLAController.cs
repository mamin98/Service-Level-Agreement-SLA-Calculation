using Microsoft.AspNetCore.Mvc;
using SLA.Application;

namespace SLA_.API;

[Route("api/[controller]")]
[ApiController]
public class SLAController : ControllerBase
{
    private readonly ICalculateSlaService _slaService;

    public SLAController(ICalculateSlaService slaService)
    {
        _slaService = slaService;
    }

    [HttpGet("calculate-deadline")]
    public async Task<ComplaintResponseDto> CalculateDeadline(
        ComplaintRequestDto request,
        CancellationToken cancellationToken
    )
    {
        var result = await _slaService.CalculateResolutionDeadlineAsync(
            request.Priority,
            request.CaptureDateTime,
            cancellationToken
        );

        return new ComplaintResponseDto(result);
    }
}
