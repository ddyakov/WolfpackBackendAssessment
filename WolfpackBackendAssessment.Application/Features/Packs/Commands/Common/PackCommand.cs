namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Common
{
	public abstract class PackCommand<TCommand> : 
        EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; } = default!;
    }
}
