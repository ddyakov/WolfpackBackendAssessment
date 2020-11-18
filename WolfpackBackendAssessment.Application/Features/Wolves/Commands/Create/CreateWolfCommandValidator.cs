namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Create
{
	using FluentValidation;

	using Application.Features.Wolves.Commands.Common;

	public class CreateWolfCommandValidator : AbstractValidator<CreateWolfCommand>
	{
		public CreateWolfCommandValidator()
			=> Include(new WolfCommandValidator<CreateWolfCommand>());
	}
}
