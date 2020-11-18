namespace WolfpackBackendAssessment.Application.Features.Common
{
	using System.Collections.Generic;

	public abstract class PaginatedOutputModel<T>
	{
		public PaginatedOutputModel(IEnumerable<T> result, int page, int totalPages)
		{
			Result = result;
			Page = page;
			TotalPages = totalPages;
		}

		public IEnumerable<T> Result { get; }

		public int Page { get; }

		public int TotalPages { get; }
	}
}
