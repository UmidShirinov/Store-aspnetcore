using Core.Dtos.UserDtos;
using MediatR;

namespace Application.App.Queries.UserQueries.GetUsers
{
	public class GetUserQuery:IRequest<IEnumerable<GetUserDto>>
	{
	}
}
