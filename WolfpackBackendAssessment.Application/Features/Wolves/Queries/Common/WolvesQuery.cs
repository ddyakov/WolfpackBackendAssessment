namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Common
{
	using static Application.Features.Common.FeaturesConstants;

	public abstract class WolvesQuery
	{
		public int Page { get; set; } = DefaultPage;
	}
}
