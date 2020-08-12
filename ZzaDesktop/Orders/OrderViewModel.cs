using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop.Orders
{
    public class OrderViewModel : BindableBase
    {
        private Guid _customerId;
        public Guid CustomerId
        {
            get { return _customerId; }
            set { SetValue(ref _customerId, value); }
        }
    }
}
