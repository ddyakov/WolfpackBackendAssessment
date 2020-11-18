namespace WolfpackBackendAssessment.Application.Features.Wolves.Commands.Delete
{
	using System.Threading;
	using System.Threading.Tasks;

	using MediatR;

	using Application.Common;

	public class DeleteWolfCommandHandler : IRequestHandler<DeleteWolfCommand, Result>
	{
		private readonly IWolfRepository _wolfRepository;

		public DeleteWolfCommandHandler(IWolfRepository wolfRepository)
			=> _wolfRepository = wolfRepository;

		public async Task<Result> Handle(
			DeleteWolfCommand request,
			CancellationToken cancellationToken)
			=> await _wolfRepository.DeleteAsync(request.Id, cancellationToken);
	}
}
