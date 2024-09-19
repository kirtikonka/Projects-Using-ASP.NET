using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June2024
{
    class Employee
    {
        public void display()
        {
            Console.WriteLine("This is Non-static method");
        }
        public static void display1()
        {
            Console.WriteLine("This is static method");
        }
        public static void display2(string name)
        {
            Console.WriteLine($"Name is {name}");
        }
        public double Add(int a, int b)
        {
            double c;
            c = a + b;
            return c;
        }
        public int Add1(int a, int b)
        {
            double c;
            c = a + b;
            int d = (int)c;
            return d;
        }
    }
}
