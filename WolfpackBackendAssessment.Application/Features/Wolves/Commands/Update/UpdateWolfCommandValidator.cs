namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Update
{
	using FluentValidation;

	using Application.Features.Wolves.Commands.Common;

	public class UpdateWolfCommandValidator : AbstractValidator<UpdateWolfCommand>
	{
		public UpdateWolfCommandValidator()
			=> Include(new WolfCommandValidator<UpdateWolfCommand>());
	}
}
