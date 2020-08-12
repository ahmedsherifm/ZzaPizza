﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;

namespace ZzaDesktop
{
    public class MainWindowViewModel: BindableBase
    {
        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _customerListViewModel.PlaceOrderRequested += NavToOrder;
        }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            {
                SetValue(ref _currentViewModel, value);
            }
        }

        public RelayCommand<string> NavCommand { get; set; }

        private void NavToOrder(Guid customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "orderPrep":
                    CurrentViewModel = _orderPrepViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = _customerListViewModel;
                    break;
            }
        }
    }
}
