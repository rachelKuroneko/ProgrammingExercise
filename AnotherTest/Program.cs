﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AnotherTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestBook[] obj = new TestBook[5];
            string path = "names.txt";

            //get data and display out of order
            ReadFromFile(obj, path);
            DisplayBookArray(obj);

            // sort the data 
            Console.WriteLine("enter any key to sort");
            Console.ReadKey();

            sortBooks(obj);

            //display the sorted data 
            Console.Clear();
            Console.WriteLine("sort-names c:\names.txt");
            DisplayBookArray(obj);
            Console.WriteLine("Finished: created names-sorted.txt");

            Console.WriteLine("press any key to write to file");
            Console.ReadKey();

            // currently assign the path to a new file 
            path = "names-sorted.txt";
            
            // if file already exist 
            if(File.Exists(path))
            {
                Console.WriteLine("File already exists");
                Console.WriteLine("press any key to exit");
                Console.ReadKey();
            }

            // if file is not yet created 
            else 
            { 
                WriteToFile(obj, "names-sorted.txt");
                Console.WriteLine("New file has been created.");
                Console.WriteLine("press any key to exit");
                Console.ReadKey();
            }
        }

        public static void ReadFromFile(TestBook[] obj, string path)
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

        // This method is using bubble sort that compares each pair of objects and swaps them in
        // the correct order 
        public static void sortBooks (TestBook[] obj)
        {
            TestBook temp;
            bool swap;

            do
            {
                swap = false;

                for (int index = 0; index < (obj.Length - 1); index++)
                {
                    // comparing if the first string is greater than the second string 
                    if (string.Compare(obj[index].Title, obj[index + 1].Title) > 0)
                    {
                        // first object will assigned to temp
                        temp = obj[index];
                        // then second object will assigned into first
                        obj[index] = obj[index + 1];
                        // later, the temp which is the first string will be placed in the second position
                        obj[index + 1] = temp;

                        swap = true;
                    }
                }
            } while (swap == true);
        }

        //display the sorted file 
        public static void DisplayBookArray(TestBook[] obj)
        {
            Console.WriteLine("Book List");
            Console.WriteLine("---------------");
            for (int index = 0; index < obj.Length; index++)
            {
                obj[index].DisplayBookInfo();
            }
        }
        
        // Display method after the sorting of the files 
        public static void WriteToFile(TestBook[] obj, string path)
        {
            StreamWriter sw = new StreamWriter(path, true);
            for (int index =0; index < obj.Length; index++)
            {
                sw.WriteLine(obj[index].Title); 
            }
            sw.Close();
        }


        public static void ReadFromFile()
        {
            throw new NotImplementedException();
        }
    }
}
