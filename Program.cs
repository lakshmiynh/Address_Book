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
            contact1.display();
            Console.WriteLine("If you Edit your Contact Deatails press 1 or if not press 0");
            int edit = int.Parse(Console.ReadLine());
            if (edit == 1)
            {
                contact1.Edit();
                contact1.display();
            }
            Console.WriteLine("If you wnat Delete Contact Deatails press 1 or if not press 0");
            int delete= int.Parse(Console.ReadLine());
            if (delete == 1)
            {
                contact1.Delete();
            }
        }
    }
}
