using AutoMapper;
using Core.Dtos.UserDtos;
using Core.Services.UnitOfWork;
using MediatR;

namespace Application.App.Queries.UserQueries.GetUsers
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<GetUserDto>>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public GetUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
		public async Task<IEnumerable<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			var result = await unitOfWork.Users.GetAllAsync();

			return mapper.Map<IEnumerable<GetUserDto>>(result);
		}
	}
}
