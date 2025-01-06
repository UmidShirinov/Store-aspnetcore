using FluentValidation;

namespace Application.App.Commands.UserCommands.RegisterUser
{
	public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
	{
		public RegisterUserCommandValidator()
		{
			RuleFor(t => t.Name).NotNull().WithMessage("Name can not be Null");
			RuleFor(t => t.Email).NotNull().WithMessage("Email can not be Null");
			RuleFor(t=>t.PasswordHash).NotNull().MinimumLength(8).WithMessage("Password can not be null and at least 8 chrachter must be");
		}
	}
}
