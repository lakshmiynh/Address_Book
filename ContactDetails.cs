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
        static Dictionary<string, AddressBook> list = new Dictionary<string, AddressBook>();
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

            list.Add(firstname, customer1);

        }

        public void Display()
        {
            foreach (var contact in list)
            {

                AddressBook person = contact.Value;
                Console.WriteLine($"First Name: {person.Firstname}");
                Console.WriteLine($"Last Name: {person.Lastname}");
                Console.WriteLine($"Address: {person.Address}");
                Console.WriteLine($"City: {person.City}");
                Console.WriteLine($"State: {person.State}");
                Console.WriteLine($"Zip Code: {person.Zip}");
                Console.WriteLine($"Phone Number: {person.Phonenumber}");
                Console.WriteLine($"Email: {person.Email}");
                Console.WriteLine();
            }
        }

        public void EditDetails()
        {
            bool continueEditing = true;
            while (continueEditing)
            {
                Console.WriteLine("Do you want to change anything? Type your first name or type 'exit' to quit editing:");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                {
                    continueEditing = false;
                    break;
                }

                if (list.ContainsKey(name) && name.ToLower() == name.ToLower())
                {
                    AddressBook person = list[name];

                    Console.WriteLine($"Choose the option to edit for {name}:");
                    Console.WriteLine("1. First name");
                    Console.WriteLine("2. Last name");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. City");
                    Console.WriteLine("5. State");
                    Console.WriteLine("6. Zip");
                    Console.WriteLine("7. Phone number");
                    Console.WriteLine("8. Email");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter new first name:");
                            person.Firstname = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter new last name:");
                            person.Lastname = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter new address:");
                            person.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter new city:");
                            person.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter new state:");
                            person.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter new zip code:");
                            person.Zip = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter new phone number:");
                            person.Phonenumber = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Enter new email:");
                            person.Email = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.WriteLine("Details updated successfully.");
                }
                else
                {
                    Console.WriteLine($"No contact found with the first name {name}.");
                }

                Console.WriteLine("Do you want to continue editing? (yes/no)");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes")
                {
                    continueEditing = false;
                }
            }
        }

       
    }
}
