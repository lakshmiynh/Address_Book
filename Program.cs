using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public  class Program
    {
        static void Main(string[] args) 
        {
            ContactDetails contact1 = new ContactDetails();
            contact1.Details();
            contact1.Display();
        }
    }
}
