namespace WolfpackBackendAssessment.Web
{
	using System.Threading.Tasks;

	using MediatR;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.DependencyInjection;

	using Common;
	using Application.Common;

	[ApiController]
	[Route("api/[controller]")]
	public abstract class ApiController : ControllerBase
	{
		public const string PathSeparator = "/";
		public const string Id = "{id:int}";

		private IMediator? _mediator;

		protected IMediator Mediator
			=> _mediator ??= (HttpContext
				.RequestServices
				.GetService<IMediator>());

		protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
			=> Mediator.Send(request).ToActionResult();

		protected Task<ActionResult> Send(IRequest<Result> request)
			=> Mediator.Send(request).ToActionResult();

		protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
			=> Mediator.Send(request).ToActionResult();
	}
}
