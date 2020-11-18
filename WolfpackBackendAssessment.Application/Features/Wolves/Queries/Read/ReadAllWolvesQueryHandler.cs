namespace WolfpackBackendAssessment.Application.Features.Wolves.Queries.Read
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
    
    using AutoMapper;

    using Application.Features.Wolves.Queries.Common;

    public class ReadAllWolvesQueryHandler : 
        WolvesQueryHandler,
        IRequestHandler<ReadAllWolvesQuery, ReadAllWolvesOutputModel>
    {
        public ReadAllWolvesQueryHandler(
            IWolfRepository wolfRepository,
            IMapper mapper)
            : base(wolfRepository, mapper)
        {
        }

        public async Task<ReadAllWolvesOutputModel> Handle(
            ReadAllWolvesQuery request,
            CancellationToken cancellationToken)
        {
            var wolves = await FindAllWolves(request, cancellationToken);
            var totalPages = await GetTotalPages(cancellationToken);

            return new ReadAllWolvesOutputModel(wolves, request.Page, totalPages);
        }
    }
}
