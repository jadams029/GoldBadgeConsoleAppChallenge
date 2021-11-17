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

            Console.WriteLine("------------------------------ dictionaries--------------------------");
            //Adding items to customers
            customerA.Items = new List<string> {"Apples","Oranges" };
            customerB.Items = new List<string> {"Apples","Oranges","Grapes" };

            //Dictionaries are key value pairs <key,value> 
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); //creating the dictionary (newing up = creating) 
            dictionary.Add("apple", "is a fruit"); // adding stuff to the dictionary 
            dictionary.Add("orange", "is another fruit");
            dictionary.Add("grape", "is a green or purple");

            //loop usining the key value approach
            //item represents the key and value of the dictionary here beacuse we did not specifiy on dictionary. 
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
                Console.WriteLine();
            }

            //using the key approach 
            //dictionary.keys restains to just using the keys. here we specified on just using the key
            foreach (var item in dictionary.Keys)
            {
                Console.WriteLine(item);
            }
            //here we specify just using the value 
            foreach (var item in dictionary.Values)
            {
                Console.WriteLine(item);
            }

            //new dictionary that is using int as the Key (word or thing being defined) and the public Customer is the "definition" of the key 
            Dictionary<int, Customer> _customerDB = new Dictionary<int, Customer>();
            int _count = 0;
            //Create
            //using _count to create new customers ID's 
            bool AddCustomer(Customer customer1)
            {
                if(customer1 == null)
                {
                    return false;
                }
                else
                {
                    _count++;
                    customer1.ID = _count;
                    _customerDB.Add(customer1.ID, customer1);
                    return true;
                }
            }
            AddCustomer(customerA);
            AddCustomer(customerB);

            Console.WriteLine(_customerDB.Count());
            //Read/helper method (get 1 customer/badge/whatever)
            Customer GetCustomerByKey(int id)
            {
                foreach (var c in _customerDB)
                {
                    if(c.Key == id)
                    {
                        return c.Value;
                    }
                }
                return null;
            }

            Console.WriteLine("Please input a Customer ID");
            var userInput = int.Parse(Console.ReadLine());
            var cust = GetCustomerByKey(userInput); //pulls everything about customer called
            Console.WriteLine(cust.FirstName);//calls first name here but change what is after the '.' to pull other info

            bool AddToCustomerList(int id, string addedItem)
            {
                Customer retrievedCustomer = GetCustomerByKey(id);
                if (retrievedCustomer != null)
                {
                    retrievedCustomer.Items.Add(addedItem);
                    return true;
                }
                else
                    return false;
            }

            AddToCustomerList(1, "cheerios");

            foreach (var c1 in _customerDB)
            {
                if (c1.Key == 1)
                {
                    Console.WriteLine(c1.Value.FirstName);
                    foreach (var items in c1.Value.Items)
                    {
                        Console.WriteLine(items);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
