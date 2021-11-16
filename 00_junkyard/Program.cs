using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_junkyard
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Customer> line = new Queue<Customer>();

            //need to create cusotomers 
            Customer customerA = new Customer(1, "Terry", "Brown");
            Customer customerB = new Customer(2, "Ethan", "Davis");
            Customer customerC = new Customer(3, "Tim", "Timmy");
            Customer customerD = new Customer(4, "Jim", "Carrey");
            //Queus is first in first out 


            //enqueue sees what is next (adds a customer to the list)
            line.Enqueue(customerA);
            line.Enqueue(customerB);
            line.Enqueue(customerC);
            line.Enqueue(customerD);
            //see who is next in line 
            Customer customer = line.Peek();
            Console.WriteLine($"{customer.FirstName}");
            //remove the first customer
            line.Dequeue();
            Console.WriteLine("We just removed the first customer");

            var nextCustomer = line.Peek();
            Console.WriteLine(nextCustomer.FirstName);

            Console.WriteLine("----------------------");
            //see all
            foreach (var item in line)
            {
                Console.WriteLine($"{item.ID}     {item.FirstName}        {item.LastName}");
            }
            Console.ReadKey();
        }
    }
}
