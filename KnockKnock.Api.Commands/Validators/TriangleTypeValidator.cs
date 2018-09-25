using KnockKnockApi.Commands;
using Microsoft.ApplicationInsights;

namespace KnockKnockApi.Validators
{
    public class TriangleTypeValidator : TelemetrySenderValidator<TriangleTypeCommand>
    {
        public TriangleTypeValidator(TelemetryClient telemetry = null) : base(telemetry)
        {
            //no-op, nothing to validate
        }
    }
}