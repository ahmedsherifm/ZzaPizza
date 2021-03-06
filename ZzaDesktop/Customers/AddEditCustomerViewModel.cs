﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    public class AddEditCustomerViewModel: BindableBase
    {
		private bool _editMode;
		private Customer _editingCustomer = null;
		private SimpleEditableCustomer _customer;
		private ICustomersRepository _repo;

		public AddEditCustomerViewModel(ICustomersRepository repo)
		{
			_repo = repo;
			CancelCommand = new RelayCommand(OnCancel);
			SaveCommand = new RelayCommand(OnSave, CanSave);
		}

		public bool EditMode
		{
			get { return _editMode; }
			set { SetProperty(ref _editMode, value); }
		}

		public SimpleEditableCustomer Customer
		{
			get { return _customer; }
			set { SetProperty(ref _customer, value); }
		}

		public RelayCommand CancelCommand { get; set; }
		
		public RelayCommand SaveCommand { get; set; }

		public event Action Done = delegate { };

		public void SetCustomer(Customer customer) 
		{ 
			_editingCustomer = customer;
			if (Customer != null) Customer.ErrorsChanged -= RaiseCanExecuteChanged;
			Customer = new SimpleEditableCustomer();
			Customer.ErrorsChanged += RaiseCanExecuteChanged;
			CopyCustomer(customer, Customer);
		}

		private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
		{
			SaveCommand.RaiseCanExecuteChanged();
		}

		private void CopyCustomer(Customer source, SimpleEditableCustomer target)
		{
			target.Id = source.Id;
			if (EditMode)
			{
				target.FirstName = source.FirstName;
				target.LastName = source.LastName;
				target.Email = source.Email;
				target.Phone = source.Phone;
			}
		}

		private bool CanSave()
		{
			return !Customer.HasErrors;
		}

		private async void OnSave()
		{
			UpdateCustomer(Customer, _editingCustomer);
			if (EditMode)
				await _repo.UpdateCustomerAsync(_editingCustomer);
			else
				await _repo.AddCustomerAsync(_editingCustomer);
			Done();
		}

		private void UpdateCustomer(SimpleEditableCustomer source, Customer target)
		{
			target.FirstName = source.FirstName;
			target.LastName = source.LastName;
			target.Email = source.Email;
			target.Phone = source.Phone;
		}

		private void OnCancel()
		{
			Done();
		}
	}
}
