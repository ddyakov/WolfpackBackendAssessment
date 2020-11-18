namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Read
{
	using MediatR;

	using Common;

	public class ReadWolfCommand : 
        EntityCommand<int>, 
        IRequest<WolfOutputModel>
    {
    }
}
