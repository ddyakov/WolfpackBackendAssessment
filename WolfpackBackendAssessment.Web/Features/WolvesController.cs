namespace WolfpackBackendAssessment.Web.Features
{
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc;

	using Application.Features;
	using Application.Features.Wolves.Queries.Read;
	using Application.Features.Wolves.Queries.Common;
	using Application.Features.Wolves.Commands.Update;
	using Application.Features.Wolves.Commands.Create;
	using Application.Features.Wolves.Commands.Delete;

	public class WolvesController : ApiController
	{
		[HttpGet]
		public async Task<ActionResult<ReadAllWolvesOutputModel>> ReadAll(
			[FromQuery] ReadAllWolvesQuery query)
			=> await Send(query);

		[HttpGet]
		[Route(Id)]
		public async Task<ActionResult<WolfOutputModel>> Read(
			[FromRoute] ReadWolfCommand query)
			=> await Send(query);

		[HttpPost]
		public async Task<ActionResult<CreateWolfOutputModel>> Create(
		   [FromBody] CreateWolfCommand command)
		   => await Send(command);

		[HttpPut]
		[Route(Id)]
		public async Task<ActionResult> Update(
			int id, 
			[FromBody] UpdateWolfCommand command)
		   => await Send(command.SetId(id));

		[HttpDelete]
		[Route(Id)]
		public async Task<ActionResult> Delete(
			[FromRoute] DeleteWolfCommand command)
		   => await Send(command);
	}
}
