using Microsoft.AspNetCore.Mvc;

using Application.App.Commands.UserCommands.RegisterUser;
using MediatR;
using Application.App.Queries.UserQueries.GetUsers;
using Core.Services.UnitOfWork;
using Application.App.Queries.UserQueries.GetUserById;
using Core.Entities;
using Application.App.Queries.UserQueries.LoginUser;
using Application.Exceptions;
using System.Reflection.Metadata.Ecma335;
using Application.App.Commands.UserCommands.ResetPassword;
using Microsoft.AspNetCore.Authorization;
using Application.App.Commands.UserCommands.LogOutUser;
using Infrastructure.Services.SendEmailService;
using Application.App.Commands.UserCommands.ForgetPassword;
using Application.App.Queries.UserQueries.TokenValidityUser;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreWithAspNetCore.Controllers
{

	[Route("api/[controller]")]
	[ApiController]


	public class UserController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly ISendEmailService sendEmailService;

		public UserController(IMediator mediator, ISendEmailService sendEmailService)
		{
			this.mediator = mediator;
			this.sendEmailService = sendEmailService;
		}

		[HttpPost]
		public async Task<IActionResult> UserRegister([FromBody] RegisterUserCommand command)
		{
			try
			{
				var result = await mediator.Send(command);
				return Ok(result);
			}
			catch (EmailAlreadyExistsException ex)
			{

				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{

				return Problem(ex.Message);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var result = await mediator.Send(new GetUserQuery());
				if (result == null)
				{
					return NotFound("No users found");
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return Problem(ex.Message);
			}
		}

		[Authorize]
		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetUserById(int id)
		{
			try
			{
				var result = await mediator.Send(new GetUserByIdQuery { Id = id });
				if (result != null)
				{
					Response response = new Response() { Result = result, Message = "Success" };
					return Ok(response);
				}
				else {
					Response response = new Response() { Result = "Null", Message = "Success" };
					return NotFound(response);
				}
			}
			catch (Exception ex)
			{

				return Problem(ex.Message);
			}
		}
		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
		{
			try
			{
				var result = await mediator.Send(loginUserQuery);
				Response response = new Response() { Result = result, Message = "Success" };
				return Ok(response);
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(ex.Message);

			}


		}

		[HttpPost("reset-password")]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
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

				return Problem(ex.Message);
			}

		}


		[Authorize]
		[HttpPost("Log-out")]
		public async Task<IActionResult> LogOut( [FromBody]LogOutUserCommand command)
		{
			try
			{
				var result = await mediator.Send(command);
				Response response = new Response()
				{
					Result = result,
					Message = "Success"
				};
				return Ok(result);

			}
			catch (Exception ex)
			{

				return Problem($"{ex.Message}");
			}
			


		}

		[HttpPost("forget-password")]
		public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand command)
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

				return Problem($"{ex.Message}");

			}
		}

		[HttpPost("token-validate")]
		public async Task <IActionResult> ValidateToken([FromBody] TokenValidityQuery query)
		{
			try
			{
				var result = await mediator.Send(query);
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
