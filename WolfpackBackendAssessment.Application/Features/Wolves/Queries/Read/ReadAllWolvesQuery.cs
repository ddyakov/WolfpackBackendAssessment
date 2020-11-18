namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Read
{
	using MediatR;

	using Common;

	public class ReadAllWolvesQuery : 
        WolvesQuery, 
        IRequest<ReadAllWolvesOutputModel>
    {
    }
}
