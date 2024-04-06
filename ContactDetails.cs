using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class ContactDetails
    {
       
            static ArrayList list = new ArrayList();
            public void Details()
            {
                Console.WriteLine("Enter your first name");
                string firstname = Console.ReadLine();

                Console.WriteLine("Enter your last name");
                string lastname = Console.ReadLine();

                Console.WriteLine("Enter your Address");
                string address = Console.ReadLine();

                Console.WriteLine("Enter your City");
                string city = Console.ReadLine();

                Console.WriteLine("Enter your State");
                string state = Console.ReadLine();

                Console.WriteLine("Enter your zip code");
                string zip = Console.ReadLine();

                Console.WriteLine("Enter your phone number");
                string phonenumber = Console.ReadLine();

                Console.WriteLine("Enter your Email");
                string email = Console.ReadLine();


                AddressBook customer1 = new AddressBook(firstname, lastname, address, city, state, zip, phonenumber, email);

                list.Add(customer1);

            }

            public void display()
            {
                foreach (AddressBook person in list)
                {

                    Console.WriteLine($"First Name: {person.Firstname}");
                    Console.WriteLine($"Last Name: {person.Lastname}");
                    Console.WriteLine($"Address: {person.Address}");
                    Console.WriteLine($"City: {person.City}");
                    Console.WriteLine($"State: {person.State}");
                    Console.WriteLine($"Zip Code: {person.Zip}");
                    Console.WriteLine($"Phone Number: {person.Phonenumber}");
                    Console.WriteLine($"Email: {person.Email}");
                }

            }
        static void Main(string[] args )
        {
            ContactDetails person1=new ContactDetails();
            person1.Details();
            person1.display();
        }
    }
}
