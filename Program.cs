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
            contact.CreateContactTable();
            contact.Displaytable();

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
                Console.WriteLine("6.Create table");
                Console.WriteLine("7.Display table");
                Console.WriteLine("8.Update contacts");
                Console.WriteLine("9.Delete contacts");
                Console.WriteLine("10.exit");

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
                        contact.CreateContactTable();
                        break;

                    case 7:
                        contact.Displaytable();
                        break;

                    case 8:
                        Console.WriteLine("Update person name");
                        Console.WriteLine("Enther the name and id of persons to update");
                        string name = Console.ReadLine();
                        int id = int.Parse(Console.ReadLine());
                        contact.Update(name, id);
                        break;

                    case 9:
                        Console.WriteLine("Enter the id of contact to delete");
                        int ide = int.Parse(Console.ReadLine());
                        contact.Delete(ide);
                        break;

                    case 10:
                        Console.WriteLine("thankyou!!!!");
                        c = false;
                        break;
                }
            }
        }
    }
}
