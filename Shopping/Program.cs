namespace Shopping
{
    namespace Shopping
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                admin admin = new admin();
                customer customer = new customer();
                Console.WriteLine("Welcome");
                while (true)
                {
                    Console.WriteLine("1. Admin giris");
                    Console.WriteLine("2. Customer giris");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Admin adinizi daxil edin:");
                            string adminName = Console.ReadLine();
                            Console.WriteLine("Admin şifrenizi daxil edin:");
                            string adminPassword = Console.ReadLine();
                            if (admin.adminLogin(adminName, adminPassword))
                            {
                                AdminMenu(admin);
                            }
                            else
                            {
                                Console.WriteLine("Giris melumatlarinda sehvlik var");
                            }
                            break;
                        case 2:
                            CustomerMenu(customer,admin);
                            break;
                    }
                }
            }

            static void AdminMenu(admin admin)
            {
                while (true)
                {
                    Console.WriteLine("1. Mehsul elave etmek");
                    Console.WriteLine("2. Mehsul silmek");
                    Console.WriteLine("3. Butun mehsullari gostermek");
                    Console.WriteLine("4. Esas menuyaya qayitmaq");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("id-ni daxil edin");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("adi daxil edin");
                            string name = Console.ReadLine();
                            Console.WriteLine("desecripton");
                            string desecereption = Console.ReadLine();
                            Console.WriteLine(" qiymeti daxil edin");
                            int price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Kateqoriyani daxil edin");
                            string cateqoriya = Console.ReadLine();
                            admin products = new admin
                            {
                                ProductId = productId,
                                ProductName = name,
                                ProductDescription = desecereption,
                                ProductPrice = price,
                                ProductCategory = cateqoriya
                            };
                            admin.addproduct(products, productId);
                            break;
                        case 2:
                            Console.WriteLine("Mehsul ID daxil edin:");
                            int removeProductId = Convert.ToInt32(Console.ReadLine());
                            admin.removeproduct(removeProductId);
                            break;
                        case 3:
                            admin.generalproduct();
                            break;
                        case 4:
                            return;
                    }
                }
            }

            static void CustomerMenu(customer customer, admin admin)
            {
                customer currentCustomer = null;

                while (true)
                {
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Logout");
                    Console.WriteLine("3. Sign");
                    Console.WriteLine("4. Producta reyting vermek");
                    Console.WriteLine("5. Esas menuyaya qayitmaq");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Customer adinizi daxil edin:");
                            string customerName = Console.ReadLine();
                            Console.WriteLine("Customer şifrənizi daxil edin:");
                            string customerPassword = Console.ReadLine();
                            if (customer.customerLogin(customerName, customerPassword))
                            {
                                currentCustomer = customer.CustomerList.FirstOrDefault(c => c.CustomerName == customerName);
                            }
                            break;
                        case 2:
                            if (currentCustomer != null)
                            {
                                Console.WriteLine("Customer ID daxil edin:");
                                int customerId = Convert.ToInt32(Console.ReadLine());
                                customer.CustomerLogout(customerId);
                                currentCustomer = null;
                            }
                            else
                            {
                                Console.WriteLine("Heç bir müştəri daxil olmayıb.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Customer ID daxil edin:");
                            int customerid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Customer adinizi daxil edin:");
                            string customername = Console.ReadLine();
                            Console.WriteLine("telefon nomrenizi daxil edin");
                            string customerphone = Console.ReadLine();
                            Console.WriteLine("sifreni daxil edin");
                            string customerpassword = Console.ReadLine();
                            Console.WriteLine("emaili daxil edin");
                            string customeremail = Console.ReadLine();

                            customer newCustomer = new customer
                            {
                                CustomerId = customerid,
                                CustomerName = customername,
                                CustomerEmail = customeremail,
                                CustomerPhone = customerphone,
                                CustomerPassword = customerpassword
                            };
                            customer.CustomerSign(newCustomer, customerid);
                            break;
                        case 4:
                            if (currentCustomer == null)
                            {
                                Console.WriteLine("Reyting vermek ucun login olun.");
                                break;
                            }
                            Console.WriteLine("Product ID daxil edin:");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Reyting verin (1-5):");
                            int rating = Convert.ToInt32(Console.ReadLine());
                            customer.rateProduct(productId, rating, currentCustomer.CustomerId, admin);
                            break;
                        case 5:
                            return;
                    }
                }
            }



        }



    }
}