using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal interface Ishopping
    {
        public bool adminLogin(string adminname, string adminpassword);
        public void addproduct(admin shopping, int pruductID);
        public void removeproduct(int productId);
        public void generalproduct();
        public void productSearchId(admin shopping, int productId);
        public void UpdateProductRating(int productId, List<CustomerRating> ratings);


    }
}
