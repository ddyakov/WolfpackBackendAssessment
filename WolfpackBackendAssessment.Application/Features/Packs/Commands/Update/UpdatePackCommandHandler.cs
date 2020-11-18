namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Update
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Application.Common;

    public class UpdatePackCommandHandler : IRequestHandler<UpdatePackCommand, Result>
    {
        private readonly IPackRepository _packRepository;

        public UpdatePackCommandHandler(IPackRepository packRepository)
            => _packRepository = packRepository;

        public async Task<Result> Handle(
            UpdatePackCommand request,
            CancellationToken cancellationToken)
        {
            var pack = await _packRepository.FindAsync(request.Id, cancellationToken);

            if (pack == null)
                return false;

            pack.UpdateName(request.Name);
            await _packRepository.SaveAsync(pack, cancellationToken);

            return Result.Success;
        }
    }
}
