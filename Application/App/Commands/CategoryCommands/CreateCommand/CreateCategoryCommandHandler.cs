using AutoMapper;
using Core.Entities;
using Core.Services.UnitOfWork;
using MediatR;

namespace Application.App.Commands.CategoryCommands.CreateCommand
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateCategoryCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
		{

			_unitOfWork = unitOfWork;
			_mapper=mapper;
		}
		public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var isCreated = await _unitOfWork.Categories.AddAsync(_mapper.Map<Category>(request));
			 await _unitOfWork.SaveChangesAsync();
			if (isCreated) return true;
			else return false;
		}
	}
}
