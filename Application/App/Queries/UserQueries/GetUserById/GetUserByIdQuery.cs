using Core.Dtos.UserDtos;
using MediatR;

namespace Application.App.Queries.UserQueries.GetUserById
{
	public class GetUserByIdQuery:IRequest<GetUserByIdDto>
	{
		public int Id { get; set; }
	}
}
