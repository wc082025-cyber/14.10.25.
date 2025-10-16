using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.Json;

namespace CharacterClass;

public static class CharacterDatabase
{
    private static readonly Dictionary<string, BaseStats> _stats = new()
    {
        ["Assassin"] = new BaseStats(
            name: "Assassin",
            vigor: 7,
            endurance: 5,
            strength: 6,
            dexterity: 12,
            intellegence: 9,
            faith: 5,
            backstory: @"Born from a Sorcerer father and a Mercenary mother. 
            The assassin has both the intellegence to cast  simple spells, and the dexterity to swiftly aquire its prey. 
            Proficient in small arms like daggers and spells that make the user almost invisible to others,
            the assassin is rarely seen and blends in to the enviroment. 
            When the target realizes its imminent doom, it is already to late. 
            Leaves no trace other than the pool of blood the victim lies in."),

        ["Chaos Magician"] = new BaseStats(
            name: "Chaos Magician",
            vigor: 7,
            endurance: 5,
            strength: 9,
            dexterity: 7,
            intellegence: 14,
            faith: 9,
            backstory: @"A Magician outcast from both the church and the sorcerers guild. 
            In Search for knowledge, the Chaos Magician is concidered a heretic and a traitor. 
            Now living life in hiding and has become a formidable opponent with ties to the occult. 
            Capable of fiery chaos magic, the forbidden knowledge. 
            Few dare approach the one who wields an axe and 
            capaple of conjuring black fire that never seems to stop burning the skin."),

        ["Cleric"] = new BaseStats(
            name: "Cleric",
            vigor: 9,
            endurance: 8,
            strength: 10,
            dexterity: 5,
            intellegence: 1,
            faith: 9,
            backstory: @"The Cleric is guided by the God of light. 
            A just warrior that can cast miracles with the sacred Thurible to heal self and others. 
            Carries a blessed flanged mace to deal holy damage to the undead. 
            Can also use some talismans, but it is considered heresy by the faith, 
            and any usage will result in being excommunicated by the church."),

        ["Deprived"] = new BaseStats(
            name: "Deprived",
            vigor: 10,
            endurance: 10,
            strength: 10,
            dexterity: 10,
            intellegence: 10,
            faith: 10,
            backstory: @"Unknown origin, wearing only rags even the poorest would discard. 
            Carrying no more than a wooden club and some improvised planks as a shield found on the ground. 
            Nobody looks twice, other than to avoid. 
            If not seen standing or moving, you would think them already dead. 
            Malnourished and gray skin. 
            Not even the crows would eat if dead."),

        ["Herald"] = new BaseStats(
            name: "Herald",
            vigor: 9,
            endurance: 13,
            strength: 14,
            dexterity: 5,
            intellegence: 2,
            faith: 13,
            backstory: @"The Herald is a crusader of the church. 
            Eqipped with plate armor, greatsword and an unfaultering faith the church is absolute. 
            Some may say the herald is brainwashed from childhood. 
            Capable of handling multiple opponents in battle by healing self while in battle. 
            Foolish for some, brave for others. 
            The herald is not afraid of death, as the belief that the God of light will show the way."),

        ["Knight"] = new BaseStats(
            name: "Knight",
            vigor: 15,
            endurance: 10,
            strength: 14,
            dexterity: 5,
            intellegence: 4,
            faith: 3,
            backstory: @"The knight comes from a long line of honorable men defending the throne. 
            Until his father betrayed the king. Now in search of redemption for the honor lost. 
            Guided by his devotion to the kingdom and new king. 
            He is on a quest to restore the legacy of his own name in hope to return home with the 
            Moonlight Greatsword to prove his loyalty. 
            Wether he dies or returns. Carries a straight sword and a shield."),

        ["Mercenary"] = new BaseStats(
            name: "Mercenary",
            vigor: 7,
            endurance: 5,
            strength: 5,
            dexterity: 14,
            intellegence: 5,
            faith: 3,
            backstory: @"Known for its agility and adaptability in combat. 
            Equipped with two curved scimitars, the mercenary exels in taking down opponents wearing light armor. 
            Fighting its way through anything and disappearing just as fast. 
            Have no alligience other than the coin paid for its services. 
            Growing in poverty has tought the mercenary not to trust. A sharp mind and even sharper blades."),

        ["Sorcerer"] = new BaseStats(
            name: "sorcerer",
            vigor: 7,
            endurance: 5,
            strength: 5,
            dexterity: 7,
            intellegence: 16,
            faith: 2,
            backstory: @"The sorcerer is a lone wanderer with very high intellegence in search 
            of futher wisdom to hone the skills learned from decades of training. 
            A dangerous opponent to those who unknowingly picks a fight.
            In search of unnatural long life, the sorcerer takes its time to learn. 
            A stoic character wielding a Mail Breaker dagger, capable of piercing the toughest armor, 
            and a catalyst for casting sorceries."),

        ["Thief"] = new BaseStats(
            name: "Thief",
            vigor: 8,
            endurance: 9,
            strength: 5,
            dexterity: 14,
            intellegence: 7,
            faith: 3,
            backstory: @"High luck, and use of bows are the defining traits. 
            Finding treasures most may have overlooked. The thief is stealthy, quick and efficient. 
            Seldom discovered, but on the occation being spotted by a guard, 
            the thief can use poisons and daggers to quickly make sure the escape. 
            Stealth and strategy, outsmarting its opponent can be just as efficient as brute force."),

        ["Warrior"] = new BaseStats(
            name: "Warrior",
            vigor: 14,
            endurance: 9,
            strength: 17,
            dexterity: 5,
            intellegence: 3,
            faith: 7,
            backstory: @"The warrior follows the ancient forgotten God. 
            The king without a name. Once a god, now stripped of all deity, and now working from the shadows. 
            The warrior comes from far away to claim back and retore the old kingdom. 
            A fierce adversary, unafraid and immense strength.  
            Wielding Greathammers and Ultra Greatswords alike. Slow, but powerful. 
            A single hit from the giant weapons the warrior has, may kill the opponent outright.
            An opponent wielding a shield may be lulled in to a false confidence 
            until the stike lands and knocks them to the ground with broken shield, 
            bones and the realization it is all over before it began."),
    };
    public static BaseStats Get(string className)
    {
        if (!_stats.TryGetValue(className, out var stats))
            throw new KeyNotFoundException($"No stats found or defined for \"{className}\".");


        return new BaseStats(
            name: stats.Name,
            vigor: stats.Vigor,
            endurance: stats.Endurance,
            strength: stats.Strength,
            dexterity: stats.Dexterity,
            intellegence: stats.Intellegence,
            faith: stats.Faith,
            backstory: stats.Backstory);
    }
    /// <summary>
    /// Call this once, or when more data is updated in the dictionary, it will override each time its called.
    /// </summary>
    public static void InitialLoadOrOverwrite()
    {
        var serialze = JsonSerializer.Serialize(_stats);
        File.WriteAllText("db_test.json", serialze);
    }

    public static void PrintCharacterData()
    {
        var loadFile = File.ReadAllText("db_test.json");
        Console.WriteLine(loadFile);
    }
    
    
}
/* Create all base stats from each class of characters. */

/// implement a json