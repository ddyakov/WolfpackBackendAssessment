namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;
	
	using Domain.Factories.Wolves;

	public class CreateWolfCommandHandler : IRequestHandler<CreateWolfCommand, CreateWolfOutputModel>
    {
        private readonly IWolfRepository _wolfRepository;
        private readonly IWolfFactory _wolfFactory;

        public CreateWolfCommandHandler(
            IWolfRepository wolfRepository,
            IWolfFactory wolfFactory)
        {
            _wolfRepository = wolfRepository;
            _wolfFactory = wolfFactory;
        }

        public async Task<CreateWolfOutputModel> Handle(
            CreateWolfCommand request,
            CancellationToken cancellationToken)
        {
            var wolf = _wolfFactory
                .WithName(request.Name)
                .WithGender(request.Gender)
                .WithLocation(request.Latitude, request.Longitude)
                .Build();

            await _wolfRepository.SaveAsync(wolf, cancellationToken);

            return new CreateWolfOutputModel(wolf.Id);
        }
    }
}
