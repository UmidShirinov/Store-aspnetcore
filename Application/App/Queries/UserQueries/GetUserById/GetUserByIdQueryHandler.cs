using AutoMapper;
using Core.Dtos.UserDtos;
using Core.Services.UnitOfWork;
using MediatR;

namespace Application.App.Queries.UserQueries.GetUserById
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDto>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}
		public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await unitOfWork.Users.GetByIdAsync(request.Id);
			return mapper.Map<GetUserByIdDto>(result);
		}
	}
}
