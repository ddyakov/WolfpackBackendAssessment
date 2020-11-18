namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Update
{
	using FluentValidation;

	using Application.Features.Packs.Commands.Common;

	public class UpdatePackCommandValidator : AbstractValidator<UpdatePackCommand>
	{
		public UpdatePackCommandValidator()
			=> Include(new PackCommandValidator<UpdatePackCommand>());
	}
}
