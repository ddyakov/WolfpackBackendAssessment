namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Read
{
	using System.Collections.Generic;

    using Common;
    using Application.Features.Common;

	public class ReadAllWolvesOutputModel : PaginatedOutputModel<WolfOutputModel>
    {
        public ReadAllWolvesOutputModel(
            IEnumerable<WolfOutputModel> wolves,
            int page,
            int totalPages)
            : base (wolves, page, totalPages)
        {
        }
    }
}
