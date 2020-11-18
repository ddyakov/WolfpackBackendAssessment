namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Create
{
	using FluentValidation;

	using Application.Features.Packs.Commands.Common;

	public class CreatePackCommandValidator : AbstractValidator<CreatePackCommand>
	{
		public CreatePackCommandValidator()
			=> Include(new PackCommandValidator<CreatePackCommand>());
	}
}
