using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnotherTest
{
    public class TestBook
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

        public void ReadFromFile(TestBook[] obj, string path)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path);

                for (int index = 0; index < obj.Length; index++)
                {
                    // new instance in the element of the array 
                    obj[index] = new TestBook();
                    // start assigning values into the instances from the text file 
                    // reading each line sequentially 
                    obj[index].Title = sr.ReadLine();
                }
            }
            catch (FileNotFoundException ex)
            {
                //Log the details to the DB
                Console.WriteLine("Please check if the file {0} exists", ex.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (sr != null)
            {
                //essential to put to close the stream reader off
                sr.Close();
            }
            Console.WriteLine("Finally Block");
        }
    }
}
