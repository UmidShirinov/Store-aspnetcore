using Application.App.Commands.CategoryCommands.CreateCommand;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreWithAspNetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{

		private readonly IMediator mediator;

		public CategoryController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost("create-category")]

		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
		{
			try
			{
				var result = await mediator.Send(command);
				Response response = new Response()
				{
					Result = result,
					Message = "Success"

				};

				return Ok(response);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

	}
}
