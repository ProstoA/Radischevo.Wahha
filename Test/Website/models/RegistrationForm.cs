using System;
using System.ComponentModel.DataAnnotations;

namespace Radischevo.Wahha.Test.Website
{
	public class RegistrationForm
	{
		#region Instance Properties
		[Required(ErrorMessage = "Please choose a login.")]
		public string Login {
			get;
			set;
		}
		
		[Required(ErrorMessage = "Please choose a password.")]
		public string Password {
			get;
			set;
		}
		#endregion
	}
}

