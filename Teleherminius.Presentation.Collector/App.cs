using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Teleherminius.Application.InformationBlock;
using Teleherminius.Core.Adapter;

namespace Teleherminius.Presentation.Collector;

public class App : BackgroundService
{
    private readonly ILogger<App> _logger;
    private readonly IHardwareInformationAdapter _hardwareInformationAdapter;
    private readonly IMediator _mediator;

    public App(
        ILogger<App> logger,
        IHardwareInformationAdapter hardwareInformationAdapter, IMediator mediator)
    {
        _logger = logger;
        _hardwareInformationAdapter = hardwareInformationAdapter;
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var information = _hardwareInformationAdapter.Get();
            
            var request = new CreateCommand(information);
            
            await _mediator.Send(request, stoppingToken);

            _logger.LogInformation(
                "{cpuName}: {cpuTime:F2}; {ram}: {ramOccupied:F2}/{ramTotal:F2};",
                information.CpuUsage.Name,
                information.CpuUsage.AverageProcessorTime,
                "RAM",
                information.RamUsage.PhysicalOccupied / Math.Pow(1024, 3),
                information.RamUsage.PhysicalTotal / Math.Pow(1024, 3)
            );

            await Task.Delay(100, stoppingToken);
        }
    }
}