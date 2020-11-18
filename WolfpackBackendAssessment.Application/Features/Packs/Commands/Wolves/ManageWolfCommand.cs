namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Wolves
{
	using MediatR;

	using Application.Common;

	public class ManageWolfCommand : 
		EntityCommand<int>, 
		IRequest<Result>
	{
		public int WolfId { get; set; }
	}
}
