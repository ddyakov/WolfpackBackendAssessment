namespace WolfpackBackendAssessment.Application.Features.Packs.Queries.Common
{
	using static Application.Features.Common.FeaturesConstants;

	public abstract class PacksQuery
	{
		public int Page { get; set; } = DefaultPage;
	}
}
