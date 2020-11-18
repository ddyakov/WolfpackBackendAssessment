namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Common
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Collections.Generic;

	using AutoMapper;

	using static Application.Features.Common.FeaturesConstants;

	public abstract class WolvesQueryHandler
	{
		private readonly IWolfRepository _wolfRepository;
		private readonly IMapper _mapper;

		protected WolvesQueryHandler(
			IWolfRepository wolfRepository,
			IMapper mapper)
		{
			_wolfRepository = wolfRepository;
			_mapper = mapper;
		}

		protected async Task<IEnumerable<WolfOutputModel>> FindAllWolves(
			WolvesQuery request,
			CancellationToken cancellationToken = default) 
			=> _mapper.Map<IEnumerable<WolfOutputModel>>(
				await _wolfRepository
					.FindAllAsync(
						(request.Page - 1) * PerPage,
						PerPage,
						cancellationToken));

		protected async Task<int> GetTotalPages(CancellationToken cancellationToken = default)
		{
			var totalWolves = await _wolfRepository.TotalAsync(cancellationToken);
			return (int)Math.Ceiling((double)totalWolves / PerPage);
		}
	}
}
