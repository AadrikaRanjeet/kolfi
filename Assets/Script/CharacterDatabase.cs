using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]//to create characters database
public class CharacterDatabase: ScriptableObject
{
    public CharacterSelection [] character;
    public int CharacterCount
    {
       //will return the number of characters
       get
       {
        return character.Length;
       }
    }
    //to get the selected character information
    public CharacterSelection GetCharacter(int index)
    {
       return character[index];
    }
}
