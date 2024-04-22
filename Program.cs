using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Address_Book.ContactDetails;

namespace Address_Book
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContactDetails contact = new ContactDetails();
            try
            {
                contact.Details();
            }
            catch (InvalidException ex)
            {
                Console.WriteLine(ex.Message);
            }
            contact.Display();

            bool c = true;
            while (c)
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1.If you Edit your Contact Deatails");
                Console.WriteLine("2.If you Delete your Contact Deatails");
                Console.WriteLine("3.Do you want Add another adressBook");
                Console.WriteLine("4.Search person accross multiple AddressBook");
                Console.WriteLine("5.Do want count the persons in city");
                Console.WriteLine("6.exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        contact.EditDetails();
                        contact.Display();
                        break;
                    case 2:
                        contact.DeletePerson();
                        break;
                    case 3:
                        contact.Add();
                        contact.Display();
                        break;
                    case 4:
                        contact.DisplaybyCity();
                        break;
                    case 5:
                        contact.CountContactsByCity();
                        break;
                    case 6:
                        Console.WriteLine("thankyou!!!!");
                        c = false;
                        break;
                }
            }
        }
    }
}
