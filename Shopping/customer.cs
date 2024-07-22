using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class customer : Icustomer
    {
        admin admin = new admin();
        private string _customerPassword;

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword
        {
            get { return _customerPassword; }
            set { _customerPassword = value; }
        }
        public string CustomerPhone { get; set; }
        public List<customer> CustomerList { get; set; }
        public List<CustomerRating> Ratings { get; set; }

        public customer()
        {
            CustomerList = new List<customer>();
            Ratings = new List<CustomerRating>();
        }

        public bool customerLogin(string customername, string customerpasword)
        {
            foreach (var item in CustomerList)
            {
                if (item != null && item.CustomerPassword == customerpasword && item.CustomerName == customername)
                {
                    Console.WriteLine("login olundu");
                    return true;
                }
            }
            Console.WriteLine("bele customer movcud deyil");
            return false;
        }


        public void CustomerLogout(int customerId)
        {
            customer removecustomer = CustomerList.Find(x => x.CustomerId == customerId);
            if (removecustomer != null)
            {
                CustomerList.Remove(removecustomer);
            }
            else
            {
                Console.WriteLine("bu id-li customer movcud deyil");
            }
        }
        public void rateProduct(int productId, int rating, int customerId, admin admin)
        {
           
            CustomerRating existingRating = Ratings.FirstOrDefault(r => r.ProductId == productId && r.CustomerId == customerId);

            if (existingRating != null)
            {
              
                existingRating.Rating = rating;
            }
            else
            {
               
                Ratings.Add(new CustomerRating { ProductId = productId, Rating = rating, CustomerId = customerId });
            }

            var product = admin.ProductList.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                double newAverageRating = Ratings.Where(r => r.ProductId == productId).Average(r => r.Rating);
                product.ProductReyting = newAverageRating;
            }
            else
            {
                Console.WriteLine("Product tapilmadi");
            }
        }

      


        public void CustomerSign(customer customer, int customerId)
        {
            foreach (var item in CustomerList)
            {
                if (item != null && item.CustomerId == customerId)
                {
                    Console.WriteLine("bu id-li Customer movcuddur");
                    return;
                }
            }
            CustomerList.Add(customer);
        }
    }
    public class CustomerRating
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
    }


}

