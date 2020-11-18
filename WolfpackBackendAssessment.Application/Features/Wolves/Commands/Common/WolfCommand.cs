namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Common
{
	public abstract class WolfCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;

        public string Gender { get; set; } = default!;

        public string Latitude { get; set; } = default!;

        public string Longitude { get; set; } = default!;
    }
}
