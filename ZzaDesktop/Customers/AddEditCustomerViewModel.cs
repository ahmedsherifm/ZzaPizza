using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Customers
{
    public class AddEditCustomerViewModel: BindableBase
    {
		private bool _editMode;

		private Customer _editingCustomer = null;

		public bool EditMode
		{
			get { return _editMode; }
			set { SetValue(ref _editMode, value); }
		}

		public void SetCustomer(Customer customer) 
		{ 
			_editingCustomer = customer; 
		}

	}
}
