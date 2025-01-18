using Core.Dtos.Category;
using MediatR;

namespace Application.App.Commands.CategoryCommands.CreateCommand
{
	public class CreateCategoryCommand:CreateCategoryDto, IRequest<bool>
	{
		
	}
}
