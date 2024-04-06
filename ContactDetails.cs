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

        public void Edit()
        {
            bool continueEditing = true;
            while (continueEditing)
            {
                Console.WriteLine("Do you want change anything type your name");

                String name = Console.ReadLine();

                Console.WriteLine(" choose the options below to edit");
                Console.WriteLine("1.Firstname");
                Console.WriteLine("2.Lastname");
                Console.WriteLine("3.Address");
                Console.WriteLine("4.City");
                Console.WriteLine("5.state");
                Console.WriteLine("6.zip");
                Console.WriteLine("7.phonenumber");
                Console.WriteLine("8.email");
                int choice = Convert.ToInt32(Console.ReadLine());

                foreach (AddressBook contacts in list)
                {
                    if (name.Equals(contacts.Firstname))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter the new firstname");
                                string newfirstname = Console.ReadLine();
                                contacts.Firstname = newfirstname;
                                break;

                            case 2:
                                Console.WriteLine("Enter the new lastname");
                                string newlastname = Console.ReadLine();
                                contacts.Lastname = newlastname;
                                break;

                            case 3:
                                Console.WriteLine("Enter the new Address");
                                string newaddress = Console.ReadLine();
                                contacts.Address = newaddress;
                                break;

                            case 4:
                                Console.WriteLine("Enter the new city");
                                string newcity = Console.ReadLine();
                                contacts.City = newcity;
                                break;

                            case 5:
                                Console.WriteLine("Enter the new state");
                                string newstate = Console.ReadLine();
                                contacts.State = newstate;
                                break;

                            case 6:
                                Console.WriteLine("Enter the new zip");
                                string newzip = Console.ReadLine();
                                contacts.Zip = newzip;
                                break;

                            case 7:
                                Console.WriteLine("Enter the new phone number");
                                string newphonenumber = Console.ReadLine();
                                contacts.Phonenumber = newphonenumber;
                                break;

                            case 8:
                                Console.WriteLine("Enter the new emailid");
                                string newemail = Console.ReadLine();
                                contacts.Email = newemail;
                                break;

                        }

                    }

                }

                Console.WriteLine("Do you want to continue editing? (yes/no)");
                string continueEditingInput = Console.ReadLine();

                if (continueEditingInput.ToLower() != "yes")
                {
                    continueEditing = false;
                }


            }
            
        }
    }
}
