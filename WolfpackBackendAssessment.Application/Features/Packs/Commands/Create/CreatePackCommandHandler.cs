namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Domain.Factories.Packs;

    public class CreatePackCommandHandler : IRequestHandler<CreatePackCommand, CreatePackOutputModel>
    {
        private readonly IPackRepository _packRepository;
        private readonly IPackFactory _packFactory;

        public CreatePackCommandHandler(
            IPackRepository packRepository,
            IPackFactory packFactory)
        {
            _packRepository = packRepository;
            _packFactory = packFactory;
        }

        public async Task<CreatePackOutputModel> Handle(
            CreatePackCommand request,
            CancellationToken cancellationToken)
        {
            var pack = _packFactory
                .WithName(request.Name)
                .Build();

            await _packRepository.SaveAsync(pack, cancellationToken);

            return new CreatePackOutputModel(pack.Id);
        }
    }
}
