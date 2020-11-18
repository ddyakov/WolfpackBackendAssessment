namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Delete
{
	using System.Threading;
	using System.Threading.Tasks;

	using MediatR;

	using Application.Common;

	public class DeletePackCommandHandler : IRequestHandler<DeletePackCommand, Result>
	{
		private readonly IPackRepository _packRepository;

		public DeletePackCommandHandler(IPackRepository packRepository)
			=> _packRepository = packRepository;

		public async Task<Result> Handle(
			DeletePackCommand request,
			CancellationToken cancellationToken)
			=> await _packRepository.DeleteAsync(request.Id, cancellationToken);
	}
}
