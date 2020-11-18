namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Common
{
	using FluentValidation;

	using Domain.Common;
	using Domain.Models.Wolves;

	using static Domain.Models.ModelConstants;

	public class WolfCommandValidator<TCommand> :
		AbstractValidator<WolfCommand<TCommand>>
		where TCommand : EntityCommand<int>
	{
		public WolfCommandValidator()
		{
			RuleFor(x => x.Name)
			.MinimumLength(MinNameLength)
			.MaximumLength(MaxNameLength)
			.NotEmpty();

			RuleFor(x => x.Gender)
			.Must(Enumeration.HasName<Gender>)
			.WithMessage("'{PropertyName}' is not valid.");

			RuleFor(x => x.Latitude).NotEmpty();
			RuleFor(x => x.Longitude).NotEmpty();
		}
	}
}
