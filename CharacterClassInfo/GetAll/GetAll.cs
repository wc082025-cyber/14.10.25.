using System;
using CharacterClass;
using Getter;  

namespace CharacterClass
{
    public static class GetAll
    {
        public static void PrintCharacter(string className)
        {
        
            BaseStats character = CharacterRepository.Get(className);

        
            Console.WriteLine($"Name:      {character.Name}");
            Console.WriteLine($"Backstory:\n{character.Backstory}");
            Console.WriteLine("Stats:");
            Console.WriteLine($"  Vigor:        {character.Vigor}");
            Console.WriteLine($"  Endurance:    {character.Endurance}");
            Console.WriteLine($"  Strength:     {character.Strength}");
            Console.WriteLine($"  Dexterity:    {character.Dexterity}");
            Console.WriteLine($"  Intelligence: {character.Intellegence}");
            Console.WriteLine($"  Faith:        {character.Faith}");
            
        }
    }
}