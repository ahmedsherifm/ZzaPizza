using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop.Customers
{
    public class SimpleEditableCustomer: BindableBase
    {
		private Guid _id;
		private string _firstName;
		private string _lastName;
		private string _email;
		private string _phone;

		public Guid Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}

		public string FirstName
		{
			get { return _firstName; }
			set { SetValue(ref _firstName, value); }
		}

		public string LastName
		{
			get { return _lastName; }
			set { SetValue(ref _lastName, value); }
		}

		public string Email
		{
			get { return _email; }
			set { SetValue(ref _email, value); }
		}

		public string Phone
		{
			get { return _phone; }
			set { SetValue(ref _phone, value); }
		}
	}
}
