namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Read
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using AutoMapper;

    using Application.Features.Packs.Queries.Common;

    public class ReadPackCommandHandler : IRequestHandler<ReadPackCommand, PackOutputModel>
    {
        private readonly IPackRepository _packRepository;
        private readonly IMapper _mapper;

        public ReadPackCommandHandler(IPackRepository packRepository, IMapper mapper)
        {
            _packRepository = packRepository;
            _mapper = mapper;
        }

        public async Task<PackOutputModel> Handle(
            ReadPackCommand request,
            CancellationToken cancellationToken)
            => _mapper.Map<PackOutputModel>(
                await _packRepository.FindAsync(request.Id, cancellationToken));
    }
}
