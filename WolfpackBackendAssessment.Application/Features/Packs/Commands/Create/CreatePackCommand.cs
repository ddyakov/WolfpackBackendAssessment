namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Create
{
	using MediatR;

	using Application.Features.Packs.Commands.Common;

	public class CreatePackCommand : 
        PackCommand<CreatePackCommand>, 
        IRequest<CreatePackOutputModel>
    {
    }
}
