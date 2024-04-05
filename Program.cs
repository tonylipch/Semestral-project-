// See https://aka.ms/new-console-template for more information

using Semestralka;

using System.IO;
using System;

class Program
{


    public static void Main(string[] args)
    {

    Console.WriteLine(Directory.GetCurrentDirectory());
        Interface menu = new Interface();
        
        menu.MenuOperations();
        

    }
    
}