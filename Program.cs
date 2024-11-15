using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{

    class Student
    {
        public double Mark;
        public string Name, Id;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
         
            List<Student> list = new List<Student>();
            while (true)
            {
                
                if (counter >= 1)
                {
                    Console.WriteLine("do you want to insert another student? \n Yes or NO ");
               Re_input:    string input = Console.ReadLine();
                  input = input.ToLower();
                    if (input == "yes")
                        goto insert;
                    else if (input == "no")
                        break;
                    else
                    {
                        Console.WriteLine("what you want? Choose to write yes or no please"); goto Re_input;
                    }
                }

            insert: Console.WriteLine("enter the information of the student please:");

                Console.Write("the name: ");

                string name= Console.ReadLine();

                Console.WriteLine("the ID: ");

                string id= Console.ReadLine();  
                
                Console.WriteLine("the mark:");

                insert_mark: double mark = Convert.ToDouble(Console.ReadLine());
                if(mark <0&& mark>100)
                {
                    Console.WriteLine("can you enter a logical degree?");
                    goto insert_mark;


                }
                list.Add(new Student { Id = id, Name = name, Mark = mark});

                counter++;
                if (counter == 10)
                    break;
            }
            Console.Clear();
            Console.WriteLine("Successful students information: \n");
            foreach (Student student in list)
                if (student.Mark >= 50)
                {
                    Console.WriteLine("Student Name: {0}\nStudent ID: {1}\nStudent Mark: {2}", student.Name, student.Id, student.Mark);
                    Console.WriteLine();
                }





        }
    }
}
