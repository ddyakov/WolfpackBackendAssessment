namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Read
{
    using MediatR;

    using Application.Features.Packs.Queries.Common;

    public class ReadPackCommand : 
        EntityCommand<int>, 
        IRequest<PackOutputModel>
    {
    }
}
