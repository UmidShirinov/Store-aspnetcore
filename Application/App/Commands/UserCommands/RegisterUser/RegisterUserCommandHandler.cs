using AutoMapper;
using Core.Services.UnitOfWork;
using FluentValidation;
using MediatR;
using Core.Entities;
using Infrastructure.Services.PasswordHashService;
using Application.Exceptions;

namespace Application.App.Commands.UserCommands.RegisterUser
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IValidator<RegisterUserCommand> validator;
		private readonly IMapper mapper;
		private readonly IPasswordService passwordService;
		public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IValidator<RegisterUserCommand> validator, IMapper mapper,IPasswordService passwordService)
		{
			this.unitOfWork = unitOfWork;
			this.validator = validator;
			this.mapper = mapper;
			this.passwordService = passwordService;
		}


		public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			validator.ValidateAndThrow(request);
			
			var isEmailTaken =  await unitOfWork.Users.IsEmailTaken(request.Email);

			if (isEmailTaken)
			{
				throw new EmailAlreadyExistsException( "Bu email artiq qeydiyatdan kechirilib");
			}

			
			request.PasswordHash = passwordService.Hash(request.PasswordHash);
			
			var result = await unitOfWork.Users.AddAsync(mapper.Map<User>(request));
			if (result)
			{
				await unitOfWork.SaveChangesAsync();

			}
			return result;

		}
	}
}
