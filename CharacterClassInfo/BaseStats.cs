namespace CharacterClass;

public class BaseStats : CharacterSelection
{
    public BaseStats() { }
    public BaseStats(
            string name,
            int vigor,
            int endurance,
            int strength,
            int dexterity,
            int intellegence,
            int faith,
            string backstory)

    {
        Name = name;
        Vigor = vigor;
        Endurance = endurance;
        Strength = strength;
        Dexterity = dexterity;
        Intellegence = intellegence;
        Faith = faith;
        Backstory = backstory;
    }
}