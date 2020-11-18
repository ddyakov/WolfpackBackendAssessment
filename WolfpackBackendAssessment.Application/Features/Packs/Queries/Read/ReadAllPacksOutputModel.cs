namespace WolfpackBackendAssessment.Application.Features.Packs.Queries.Read
{
    using System.Collections.Generic;

	using Application.Features.Common;
    using Application.Features.Packs.Queries.Common;

	public class ReadAllPacksOutputModel : PaginatedOutputModel<PackOutputModel>
	{
        public ReadAllPacksOutputModel(
            IEnumerable<PackOutputModel> packs,
            int page,
            int totalPages)
            : base (packs, page, totalPages)
        {
        }
    }
}
