namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Update
{
	using MediatR;

	using Application.Common;
	using Application.Features.Wolves.Commands.Common;

	public class UpdateWolfCommand : 
        WolfCommand<UpdateWolfCommand>, 
        IRequest<Result>
    {
    }
}
