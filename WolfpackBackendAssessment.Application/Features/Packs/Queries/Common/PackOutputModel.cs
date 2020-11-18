namespace WolfpackBackendAssessment.Application.Features.Packs.Queries.Common
{
    using System.Collections.Generic;

    using Application.Mapping;
    using Domain.Models.Packs;
	using Application.Features.Wolves.Queries.Common;

	public class PackOutputModel : IMapFrom<Pack>
    {
		public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public IReadOnlyCollection<WolfOutputModel> Wolves { get; private set; } = new List<WolfOutputModel>();
    }
}
