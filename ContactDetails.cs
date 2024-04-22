﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;


namespace Address_Book
{
    public class ContactDetails
    {
        static Dictionary<string, AddressBook> list = new Dictionary<string, AddressBook>();

        public void Details()
        {   
                string firstname = ValidateInput("First Name", @"^[A-Za-z]+$");

                string lastname = ValidateInput("Last Name", @"^[A-Za-z]+$");

                string key = $"{firstname.ToLower()}_{lastname.ToLower()}";

                if (list.ContainsKey(key))
                {
                    throw new InvalidException("Contact with the same first name and last name already exists.");
                }

                 Console.WriteLine("Enter your Address");
                 string address = Console.ReadLine();
                 File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\contactfile.txt", $"{address}\n.");

                Console.WriteLine("Enter your City");
                string city = Console.ReadLine();

                 File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\contactfile.txt", $"{city}\n.");

                 Console.WriteLine("Enter your State");
                 string state = Console.ReadLine();

                 File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\contactfile.txt", $"{state}\n.");

                string zip = ValidateInput("Zip Code", @"^\d{6}$");

                string phonenumber = ValidateInput("Phone Number", @"^\d{10}$");

                string email = ValidateInput("Email", @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

                Console.WriteLine(File.ReadAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\contactfile.txt"));

                AddressBook customer1 = new AddressBook(firstname, lastname, address, city, state, zip, phonenumber, email);
                list.Add(key, customer1);
        }

        private string ValidateInput(string fieldName, string regexPattern)
        {
            string input;
            Regex regex = new Regex(regexPattern);
            do
            {
                Console.WriteLine($"Enter your {fieldName}");
                input = Console.ReadLine();

                File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\contactfile.txt", $"{ input }\n.");

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine($"Invalid {fieldName}. Please try again.");
                }
            } while (!regex.IsMatch(input));
            return input;
        }

        public class InvalidException : Exception
        {
            public InvalidException(string message) : base(message)
            {
            }
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

        public void DeletePerson()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            if (list.ContainsKey(name))
            {
                list.Remove(name);
                Console.WriteLine($"Contact with the first name {name} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No contact found with the first name {name}.");
            }
        }

        public void Add()
        {
            try
            {
                Details();
            }
            catch (InvalidException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void DisplaybyCity()
        {
            Console.WriteLine("Enter the city");
            string city = Console.ReadLine();

            var contactsInCity = list.Values
            .Where(person => person.City.ToLower() == city.ToLower()); 

            if (contactsInCity.Any())  // linq  method
            {

                foreach (var person in contactsInCity)
                {
                    Display();

                }
            }
            else
            {
                Console.WriteLine($"No contacts found in the city: {city}");
            }
        }

        public void CountContactsByCity()
        {
            Console.WriteLine("Enter the city");
            string city= Console.ReadLine();

            var contactsCount = list.Values
                .Where(person => person.City.ToLower() == city.ToLower())
                .Count();

            if (contactsCount > 0)
            {
                Console.WriteLine($"Number of contacts in {city}: {contactsCount}");
            }
            else
            {
                Console.WriteLine($"No contacts found in {city}.");
            }
        }

    }
}
