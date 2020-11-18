namespace WolfpackBackendAssessment.Application.Features.Packs.Commands.Update
{
    using MediatR;

    using Application.Common;
    using Application.Features.Packs.Commands.Common;

    public class UpdatePackCommand : 
        PackCommand<UpdatePackCommand>, 
        IRequest<Result>
    {
    }
}
