﻿using System;
using System.Collections.ObjectModel;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
	public class CustomerListViewModel: BindableBase
    {
		private ICustomersRepository _repo = new CustomersRepository();
		private ObservableCollection<Customer> _customers;

		public CustomerListViewModel()
		{
			PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
			AddCustomerCommand = new RelayCommand(OnAddCustomer);
			EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
		}

		public ObservableCollection<Customer> Customers
		{
			get { return _customers; }
			set { SetValue(ref _customers, value); }
		}

		public RelayCommand<Customer> PlaceOrderCommand { get; private set; }
		public RelayCommand AddCustomerCommand { get; private set; }
		public RelayCommand<Customer> EditCustomerCommand { get; private set; }

		public event Action<Guid> PlaceOrderRequested = delegate { };
		public event Action<Customer> AddCustomerRequested = delegate { };
		public event Action<Customer> EditCustomerRequested = delegate { };

		public async void LoadCustomers()
		{
			Customers = new ObservableCollection<Customer>(await _repo.GetCustomersAsync());
		}

		private void OnPlaceOrder(Customer customer)
		{
			PlaceOrderRequested(customer.Id);
		}

		private void OnEditCustomer(Customer customer)
		{
			EditCustomerRequested(customer);
		}

		private void OnAddCustomer()
		{
			AddCustomerRequested(new Customer { Id = Guid.NewGuid() });
		}
	}
}
