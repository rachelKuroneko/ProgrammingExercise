using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AnotherTest
{
    class TestBook
    {
        public string Title { get; set; }

        public TestBook()
        {
            Title = "N/A";
        }

        public void DisplayBookInfo()
        {
            Console.WriteLine("Title: {0}", Title);

            Console.WriteLine("------------------------------");
        }
    }
}
