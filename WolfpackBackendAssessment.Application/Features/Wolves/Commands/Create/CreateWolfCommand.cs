namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Create
{
	using MediatR;

	using Application.Features.Wolves.Commands.Common;

	public class CreateWolfCommand : 
		WolfCommand<CreateWolfCommand>, 
		IRequest<CreateWolfOutputModel>
    {
    }
}
