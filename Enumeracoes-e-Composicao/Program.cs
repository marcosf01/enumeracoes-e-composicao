using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumeracoes_e_Composicao.Entities;
using Enumeracoes_e_Composicao.Entities.Enum;

namespace Enumeracoes_e_Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            
            Console.WriteLine("Enter order date: ");
            
            Console.Write("Status: ");
            OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            DateTime state = DateTime.Now;

            Order order = new Order(state, os, new Client(name, email, birthDate));

            Console.Write("How many items to this order? ");
            int quantity = int.Parse(Console.ReadLine());


            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantityItem = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantityItem, productPrice, new Product(productName, productPrice));
                order.AddItem(orderItem);
            }

            Console.WriteLine();

            Console.WriteLine("ORDER SUMMARY:");
            order.ToString();

            foreach (OrderItem item in order.Items)
            {
                Console.WriteLine(item.Product.Name 
                    + ", $" 
                    + item.Price 
                    + ", Quantity: " 
                    + item.Quantity 
                    + ", Subtotal: $" 
                    + item.SubTotal());
            }

            Console.WriteLine("Total price: $" + order.Total().ToString("F2"));
        }
    }
}
