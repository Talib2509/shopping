using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal interface Icustomer
    {
        public bool customerLogin(string customername, string customerpasword);

        public void CustomerLogout( int customerId);
        public void CustomerSign(customer customer, int customerId);
        public void rateProduct(int productId, int rating, int customerId, admin admin);
    }
}
