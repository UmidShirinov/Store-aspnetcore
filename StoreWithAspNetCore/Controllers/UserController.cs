using Core.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreWithAspNetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]


	public class UserController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _unitOfWork.Users.GetAllAsync();
			return Ok(users);
		}
	}
}
