namespace WolfpackBackendAssessment.Web.Features
{
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.Mvc;

	using Application.Features;
	using Application.Features.Packs.Queries.Read;
	using Application.Features.Packs.Commands.Read;
	using Application.Features.Packs.Queries.Common;
	using Application.Features.Packs.Commands.Create;
	using Application.Features.Packs.Commands.Update;
	using Application.Features.Packs.Commands.Delete;
	using Application.Features.Packs.Commands.Wolves;

	public class PacksController : ApiController
	{
		[HttpGet]
		public async Task<ActionResult<ReadAllPacksOutputModel>> ReadAll(
			[FromQuery] ReadAllPacksQuery query)
			=> await Send(query);

		[HttpGet]
		[Route(Id)]
		public async Task<ActionResult<PackOutputModel>> Read(
			[FromRoute] ReadPackCommand query)
			=> await Send(query);

		[HttpPost]
		public async Task<ActionResult<CreatePackOutputModel>> Create(
		   [FromBody] CreatePackCommand command)
		   => await Send(command);

		[HttpPut]
		[Route(Id)]
		public async Task<ActionResult> Update(
			int id,
			[FromBody] UpdatePackCommand command)
			=> await Send(command.SetId(id));

		[HttpPut]
		[Route("{id:int}/wolves/add/{wolfId:int}")]
		public async Task<ActionResult> AddWolf(
			[FromRoute] AddWolfCommand command)
			=> await Send(command);

		[HttpPut]
		[Route("{id:int}/wolves/remove/{wolfId:int}")]
		public async Task<ActionResult> RemoveWolf(
			[FromRoute] RemoveWolfCommand command)
			=> await Send(command);

		[HttpDelete]
		[Route(Id)]
		public async Task<ActionResult> Delete(
			[FromRoute] DeletePackCommand command)
		   => await Send(command);
	}
}
