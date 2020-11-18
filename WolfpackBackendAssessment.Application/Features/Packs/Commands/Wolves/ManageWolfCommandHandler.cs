namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Wolves
{
	using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using MediatR;

    using Application.Common;
    using Domain.Models.Packs;
    using Domain.Models.Wolves;
    using Application.Features.Wolves;

	public class ManageWolfCommandHandler : 
        IRequestHandler<AddWolfCommand, Result>,
        IRequestHandler<RemoveWolfCommand, Result>
    {
        private readonly IPackRepository _packRepository;
        private readonly IWolfRepository _wolfRepository;

        public ManageWolfCommandHandler(
            IPackRepository packRepository,
            IWolfRepository wolfRepository)
        {
            _packRepository = packRepository;
            _wolfRepository = wolfRepository;
        }

        public async Task<Result> Handle(
            AddWolfCommand request, 
            CancellationToken cancellationToken)
        {
            var pack = await FindPackAsync(request.Id, cancellationToken);

            if (pack == null)
                return false;

            var wolf = await FindWolfAsync(request.WolfId, cancellationToken);

            if (wolf == null)
                return false;

            if (pack.Wolves.Any(x => x.Id == wolf.Id))
                return Result.Failure(new List<string>() { "This wolf is already in the pack." });

            var otherPacksWolves = (await _packRepository.FindAllAsync())
                .Where(x => x.Id != pack.Id)
                .SelectMany(x => x.Wolves)
                .ToList();

			if (otherPacksWolves.Any(x => x.Id == wolf.Id))
                return Result.Failure(new List<string>() { "This wolf is already in another pack." });

            return await ManagePackWolvesWithResult(pack, wolf, cancellationToken);
        }

        public async Task<Result> Handle(
            RemoveWolfCommand request,
            CancellationToken cancellationToken)
        {
            var pack = await FindPackAsync(request.Id, cancellationToken);

            if (pack == null)
                return false;

            var wolf = await FindWolfAsync(request.WolfId, cancellationToken);

            if (wolf == null)
                return false;

            if (pack.Wolves.All(x => x.Id != wolf.Id))
                return Result.Failure(new List<string>() { "This wolf is not in the pack." });

            return await ManagePackWolvesWithResult(pack, wolf, cancellationToken, false);
        }

        private Task<Pack> FindPackAsync(
            int id,
            CancellationToken cancellationToken)
            => _packRepository.FindAsync(id, cancellationToken);

        private Task<Wolf> FindWolfAsync(
            int id,
            CancellationToken cancellationToken)
            => _wolfRepository.FindAsync(id, cancellationToken);

        private async Task<Result> ManagePackWolvesWithResult(
            Pack pack, 
            Wolf wolf, 
            CancellationToken cancellationToken, 
            bool add = true)
		{
            if (add)
                pack.AddWolf(wolf);
            else
                pack.RemoveWolf(wolf);

            await _packRepository.SaveAsync(pack, cancellationToken);

            return Result.Success;
        }
    }
}
