namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Common
{
    using AutoMapper;

    using Mapping;
    using Domain.Models.Wolves;

	public class WolfOutputModel : IMapFrom<Wolf>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Gender { get; private set; } = default!;

        public string Location { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Wolf, WolfOutputModel>()
                .ForMember(x => x.Gender, cfg => cfg
                    .MapFrom(x => x.Gender.Name))
                .ForMember(x => x.Location, cfg => cfg
                    .MapFrom(x => $"{x.Location.Latitude}:{x.Location.Longitude}"));
    }
}
