namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Common
{
	using FluentValidation;

	using static Domain.Models.ModelConstants;

	public class PackCommandValidator<TCommand> : 
		AbstractValidator<PackCommand<TCommand>>
		where TCommand : EntityCommand<int>
	{
		public PackCommandValidator()
		{
			RuleFor(c => c.Name)
			.MinimumLength(MinNameLength)
			.MaximumLength(MaxNameLength)
			.NotEmpty();
		}
	}
}
