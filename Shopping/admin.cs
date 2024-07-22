using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class admin : Ishopping
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }
        public int ProductPrice { get; set; }
        public double ProductReyting { get; set; }
        public List<admin> ProductList { get; set; }
        public List<CustomerRating> Ratings { get; set; }
        private string _adminName;
        private string _adminPassword;

        public string AdminName
        {
            get { return _adminName; }
            set { _adminName = value; }
        }

        public string AdminPassword
        {
            get { return _adminPassword; }
            set { _adminPassword = value; }
        }

        public admin()
        {
            ProductList = new List<admin>();
            Ratings = new List<CustomerRating>();
            AdminName = "admin";
            AdminPassword = "password";
            ProductReyting = 0;
        }

        public void addproduct(admin shopping, int productID)
        {
            foreach (var item in ProductList)
            {
                if (item != null && item.ProductId == productID)
                {
                    Console.WriteLine("bu id-li product movcuddur");
                    return;
                }
            }
            ProductList.Add(shopping);
        }

        public bool adminLogin(string adminname, string adminpassword)
        {
            return AdminName == adminname && AdminPassword == adminpassword;
        }

        public void removeproduct(int productId)
        {
            admin removeproduct = ProductList.Find(x => x.ProductId == productId);
            if (removeproduct != null)
            {
                ProductList.Remove(removeproduct);
            }
            else
            {
                Console.WriteLine("bu id-li product movcud deyil");
            }
        }

        public void generalproduct()
        {
            foreach (var item in ProductList)
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductReyting);
            }
        }

        public void productSearchId(admin shopping, int productId)
        {
            admin product = new admin();
            bool isproduct = false;
            foreach (var item in ProductList)
            {
                if (item != null && item.ProductId == productId)
                {
                    isproduct = true;
                    product = item;
                }
            }
            if (!isproduct)
            {
                Console.WriteLine("bele id-li movcud deyil");
            }
            else
            {
                Console.WriteLine(product.ProductId);
                Console.WriteLine(product.ProductName);
            }
        }

        public void UpdateProductRating(int productId, List<CustomerRating> ratings)
        {
            admin product = ProductList.Find(p => p.ProductId == productId);
            if (product != null)
            {
                double averageRating = ratings.Average(r => r.Rating);
                product.ProductReyting = averageRating;
            }
        }
    }


}
