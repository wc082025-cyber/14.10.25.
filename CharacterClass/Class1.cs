namespace CharacterClass;

public abstract class CharacterSelection
{
    public string Name { get; set; } = string.Empty;
    public int Vigor { get; set; }
    public int Endurance { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intellegence { get; set; }
    public int Faith { get; set; }
    public string Backstory { get; set; } = string.Empty;
}
