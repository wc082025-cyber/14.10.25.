// See https://aka.ms/new-console-template for more information
//using Core.Models;


using System;
using CharacterClass;   
using Getter;

namespace ClassesInformation
{
    internal class Program
    {
        static void Main()
        {
            CharacterDatabase.InitialLoadOrOverwrite();

            CharacterDatabase.PrintCharacterData();
        

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}



/*GenericEntity<int> IntStorer = new();
IntStorer.StoredValue = 10;

GenericEntity<string> StringStorer = new();
StringStorer.StoredValue = "Hello, world!";

List<float> floats = [];
*/
