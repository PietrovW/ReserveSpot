using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Wolverine;

namespace ReserveSpot.Application.Shared.Behaviours;
public class PerformanceBehaviour
{
    private readonly Stopwatch _stopwatch = new();

    public void Before()
    {
        _stopwatch.Start();
    }

    public void Finally(ILogger logger, Envelope envelope)
    {
        _stopwatch.Stop();
        logger.LogDebug("Envelope {Id} / {MessageType} ran in {Duration} milliseconds",
            envelope.Id, envelope.MessageType, _stopwatch.ElapsedMilliseconds);
    }
}
