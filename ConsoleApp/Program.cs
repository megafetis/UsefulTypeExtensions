using System;
using SharedClasses;
using UsefulTypeExtensions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var siInherit = typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<string>));

            Console.WriteLine("Hello World!");
        }
    }
}
