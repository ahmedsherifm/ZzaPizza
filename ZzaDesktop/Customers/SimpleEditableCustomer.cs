using System;
using System.ComponentModel.DataAnnotations;

namespace ZzaDesktop.Customers
{
	public class SimpleEditableCustomer: ValidatableBindableBase
    {
		private Guid _id;
		private string _firstName;
		private string _lastName;
		private string _email;
		private string _phone;

		public Guid Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		[Required]
		public string FirstName
		{
			get { return _firstName; }
			set { SetProperty(ref _firstName, value); }
		}

		[Required]
		public string LastName
		{
			get { return _lastName; }
			set { SetProperty(ref _lastName, value); }
		}

		[EmailAddress]
		public string Email
		{
			get { return _email; }
			set { SetProperty(ref _email, value); }
		}

		[Phone]
		public string Phone
		{
			get { return _phone; }
			set { SetProperty(ref _phone, value); }
		}
	}
}
