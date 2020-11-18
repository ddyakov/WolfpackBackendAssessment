namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Domain.Common;
    using Application.Common;
	using Domain.Models.Wolves;

	public class UpdateWolfCommandHandler : IRequestHandler<UpdateWolfCommand, Result>
    {
        private readonly IWolfRepository _wolfRepository;

        public UpdateWolfCommandHandler(IWolfRepository wolfRepository)
            => _wolfRepository = wolfRepository;

        public async Task<Result> Handle(
            UpdateWolfCommand request,
            CancellationToken cancellationToken)
        {
            var wolf = await _wolfRepository.FindAsync(request.Id, cancellationToken);

            if (wolf == null)
                return false;

            wolf
                .UpdateName(request.Name)
                .UpdateGender(Enumeration.FromName<Gender>(request.Gender))
                .UpdateLocation(request.Latitude, request.Longitude);

            await _wolfRepository.SaveAsync(wolf, cancellationToken);

            return Result.Success;
        }
    }
}
