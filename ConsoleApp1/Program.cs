using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConnectingMySql.ConnectingMySqlMain();
            Fibonacci.FibonacciMain();

            Console.ReadLine();
        }
    }
}