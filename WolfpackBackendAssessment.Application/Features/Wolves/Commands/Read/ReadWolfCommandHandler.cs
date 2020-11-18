namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Read
{
	using System.Threading;
	using System.Threading.Tasks;

    using MediatR;

    using AutoMapper;

    using Application.Features.Wolves.Queries.Common;
    using Application.Features.Wolves.Queries.Read;

    public class ReadWolfCommandHandler : IRequestHandler<ReadWolfCommand, WolfOutputModel>
    {
        private readonly IWolfRepository _wolfRepository;
        private readonly IMapper _mapper;

        public ReadWolfCommandHandler(IWolfRepository wolfRepository, IMapper mapper)
        {
            _wolfRepository = wolfRepository;
            _mapper = mapper;
        }

        public async Task<WolfOutputModel> Handle(
            ReadWolfCommand request,
            CancellationToken cancellationToken)
            => _mapper.Map<WolfOutputModel>(
                    await _wolfRepository.FindAsync(request.Id, cancellationToken));
    }
}
