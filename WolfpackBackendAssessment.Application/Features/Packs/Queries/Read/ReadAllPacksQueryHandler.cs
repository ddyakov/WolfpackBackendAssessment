namespace WolfpackBackendAssessment.Application.Features.Packs.Queries.Read
{
	using System.Threading;
	using System.Threading.Tasks;

	using MediatR;

	using AutoMapper;

	using Application.Features.Packs.Queries.Common;

	public class ReadAllPacksQueryHandler : 
		PacksQueryHandler,
		IRequestHandler<ReadAllPacksQuery, ReadAllPacksOutputModel>
	{
		public ReadAllPacksQueryHandler(
			IPackRepository packRepository,
			IMapper mapper)
			: base(packRepository, mapper)
		{
		}

		public async Task<ReadAllPacksOutputModel> Handle(
			ReadAllPacksQuery request,
			CancellationToken cancellationToken)
		{
			var packs = await FindAllPacks(request, cancellationToken);
			var totalPages = await GetTotalPages(cancellationToken);

			return new ReadAllPacksOutputModel(packs, request.Page, totalPages);
		}
	}
}
