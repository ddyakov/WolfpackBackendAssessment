namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Delete
{
	using MediatR;

	using Application.Common;

	public class DeletePackCommand : 
		EntityCommand<int>, 
		IRequest<Result>
	{
	}
}
