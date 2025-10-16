/*
using System;

namespace CharacterClass;
*/

/*implementere en listetype vi kaller CharacterList som tar inn, og jobber med typen TCharacter */
public class CharacterList<TCharacter>(int capacity = 0, int growthFactor = 1) : ICharacterList<TCharacter> where TCharacter : ICharacter
{
    private TCharacter[] _data new TCharacter[capacity];


     /* Her skal vi sette opp måter å lagre store mengder av TCharacter typen, samt måter å behandle de på. */
    public int Length => _data.Length;


    /// <summary>
    /// Vi trenger en måte å holde oversikt over neste ledige plass i arrayet vårt,
    /// hvor vi kan adde et nytt våpen uten å overskrive et gammelt, det gjør vi via denne integeren.
    /// </summary>
    private int _indexOfSpareSpaceInData;

    /// <summary>
    /// Vår growthfactor er hvor mye det interne _data arrayet skal vokse hver gang det må vokse. 
    /// </summary>
    private int _growthFactor = growthFactor;

    /// <summary>
    /// Dette er en intern metode som vokser vårt interne array. Det overskriver det gamle eksisterende arrayet med et nytt array. 
    /// </summary>
    private void _growUnderlyingArray()
    {
        TCharacter[] newDataArray = new TCharacter[_capacity + _growthFactor];
        _data = [.. newDataArray.Select((_, index) => index < _capacity && _data[index] is not null ? _data[index] : default!)];
        _capacity = _data.Length;
    }
    /// <summary>
    /// Dette er en metode som inserter en ny karakter i arrayet vårt, det vokser automatisk arrayet hvis
    /// det ikke er plass. 
    /// </summary>
    /// <param name="character">Karakteren som skal insertes. </param>
    public void InsertNewCharacter(TCharacter character)
    {
        if (_indexOfSpareSpaceInData >= _capacity)
        {
            _growUnderlyingArray();
        }
        _data[_indexOfSpareSpaceInData] = character;
        _indexOfSpareSpaceInData++;
    }

    /// <summary>
    /// En metode som "Popper" ut det siste arrayet i listen vår. 
    /// </summary>
    /// <returns></returns>
    public TCharacter PopCharacter()
    {
        //Legg merke til --_indexOfSpareSpaceInData, her tar vi et steg tilbake i arrayet vårt, og fjerner det våpenet. 
        //Vi dekrementer også index og sier den posisjonen er "ledig". 
        var character = _data[--_indexOfSpareSpaceInData];
        return character;
    }

    /// <summary>
    /// Her er en mer avansert måte å accesse det underliggende arrayet på. 
    /// this nøkkelordet refererer til objektet laget av blueprinten, og vi kan bruke this[in index] for å tillate array syntax også på vår datatype.
    /// Det vil si at hvis vi lager en WeaponList list, kan vi accesse første posisjon i denne listen via: list[0]. Handy!
    /// </summary>
    /// <param name="index">Dette er indexen i det underliggende arrayet vi prøver å eksponere ut for brukeren av datastrukturen vår. </param>
    /// <returns>Verdien i index.</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public TCharacter this[int index] { get
        {
            if (index >= _capacity) throw new IndexOutOfRangeException();
            return _data[index];
        } set => _data[index] = value; }

}
