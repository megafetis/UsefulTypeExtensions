using System;
using SharedClasses;
using UTypeExtensions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var siInherit = typeof(BaseEntity<>).InheritsOrImplements(typeof(object));

            Console.WriteLine("Hello World!");
        }
    }
}
