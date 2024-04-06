using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContactDetails contact1 = new ContactDetails();
            contact1.Details();
            contact1.Display();

            Console.WriteLine("Enter your choice");
            Console.WriteLine("1.If you Edit your Contact Deatails");
            Console.WriteLine("2.If you Delete your Contact Deatails");
            Console.WriteLine("3.Do you want Add another adress");
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
          }
        }
    }
}
