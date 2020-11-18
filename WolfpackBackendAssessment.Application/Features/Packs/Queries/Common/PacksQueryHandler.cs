namespace WolfpackBackendAssessment.Application.Features.Packs.Queries.Common
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Collections.Generic;

	using AutoMapper;

	using static Application.Features.Common.FeaturesConstants;

	public abstract class PacksQueryHandler
	{
		private readonly IPackRepository _packRepository;
		private readonly IMapper _mapper;

		protected PacksQueryHandler(
			IPackRepository packRepository,
			IMapper mapper)
		{
			_packRepository = packRepository;
			_mapper = mapper;
		}

		protected async Task<IEnumerable<PackOutputModel>> FindAllPacks(
			PacksQuery request,
			CancellationToken cancellationToken = default) =>
			_mapper.Map<IEnumerable<PackOutputModel>>(
				await _packRepository
					.FindAllAsync(
						(request.Page - 1) * PerPage,
						PerPage,
						cancellationToken));

		protected async Task<int> GetTotalPages(CancellationToken cancellationToken = default)
		{
			var totalPacks = await _packRepository.TotalAsync(cancellationToken);
			return (int)Math.Ceiling((double)totalPacks / PerPage);
		}
	}
}
