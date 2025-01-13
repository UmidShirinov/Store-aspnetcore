using MediatR;

namespace Application.App.Commands.UserCommands.ForgetPassword
{
	public class ForgetPasswordCommand:IRequest<string>
	{
		public string Email { get; set; }
		private int _number;
		public int Number
		{
			get
			{
				// Əgər `Number` təyin edilməyibsə, təsadüfi bir rəqəm təyin et
				if (_number == 0)
				{
					var random = new Random();
					_number = random.Next(1, 999); // 1000 ilə 9999 arasında təsadüfi ədəd
				}
				return _number;
			}
			set
			{
				_number = value;
			}
		}
	}
}
