using System;
using Zza.Data;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;
using ZzaDesktop.Services;
using Unity;

namespace ZzaDesktop
{
    public class MainWindowViewModel: BindableBase
    {
        private CustomerListViewModel _customerListViewModel;
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel;
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);

            _customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();
            _addEditCustomerViewModel = ContainerHelper.Container.Resolve<AddEditCustomerViewModel>();

            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerListViewModel.EditCustomerRequested += NavToEditCustomer;
            _addEditCustomerViewModel.Done += NavToCustomerList;
        }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            {
                SetProperty(ref _currentViewModel, value);
            }
        }

        public RelayCommand<string> NavCommand { get; set; }

        private void NavToOrder(Guid customerId)
        {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private void NavToEditCustomer(Customer customer)
        {
            _addEditCustomerViewModel.EditMode = true;
            _addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavToAddCustomer(Customer customer)
        {
            _addEditCustomerViewModel.EditMode = false;
            _addEditCustomerViewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavToCustomerList()
        {
            CurrentViewModel = _customerListViewModel;
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
