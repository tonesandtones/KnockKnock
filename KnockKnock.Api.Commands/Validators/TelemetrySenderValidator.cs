using FluentValidation;
using FluentValidation.Results;
using KnockKnockApi.Commands;
using Microsoft.ApplicationInsights;

namespace KnockKnockApi.Validators
{
    public class TelemetrySenderValidator<T> : AbstractValidator<T>
    {
        private readonly TelemetryClient _telemetry;

        public TelemetrySenderValidator(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            if (context.InstanceToValidate is IDictionaryCommandExtension instance)
            {
                _telemetry?.TrackEvent(instance.CommandName, instance.Properties);
                _telemetry?.Flush();
            }
            
            return base.PreValidate(context, result);
        }
    }
}