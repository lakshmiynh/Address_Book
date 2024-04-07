using System;
using System.Collections.Generic;
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
            ContactDetails contact1 = new ContactDetails();
            try
            {
                contact1.Details();
            }
            catch(InvalidException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            contact1.Display();

            Console.WriteLine("Enter your choice");
            Console.WriteLine("1.If you Edit your Contact Deatails");
            Console.WriteLine("2.If you Delete your Contact Deatails");
            Console.WriteLine("3.Do you want Add another adressBook");
            Console.WriteLine("4.Search person accross multiple AddressBook");
            Console.WriteLine("5.Do want count the persons in city");
            int choice=int.Parse(Console.ReadLine());
            
          switch(choice)
          {
                case 1:
                        contact1.EditDetails();
                        contact1.Display();
                    break;
                case 2:
                    contact1.DeletePerson();
                    break;
                case 3:
                    contact1.Add();
                    contact1.Display();
                    break;
                case 4:
                    contact1.DisplaybyCity();
                    break;
                case 5: contact1.CountContactsByCity(); 
                    break;  
          }
        }
    }
}
