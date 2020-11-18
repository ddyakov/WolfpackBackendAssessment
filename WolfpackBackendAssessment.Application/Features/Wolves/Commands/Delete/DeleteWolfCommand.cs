namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Delete
{
    using MediatR;

	using Application.Common;

	public class DeleteWolfCommand : 
		EntityCommand<int>, 
		IRequest<Result>
	{
    }
}
