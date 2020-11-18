namespace WolfpackBackendAssessment.Application.Features.Packs.Queries.Read
{
	using MediatR;

	using Application.Features.Packs.Queries.Common;

	public class ReadAllPacksQuery : 
		PacksQuery, 
		IRequest<ReadAllPacksOutputModel>
	{
	}
}
