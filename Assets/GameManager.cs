using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character2[] characters;
    public  Character2 currentCharacter;
  private void Awake()
  {
    if(instance==null)
    {
        instance=this;
    }
    else
    {
        Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
  }
  void Start()
  {
    if(characters.Length>0 )
    {
        currentCharacter=characters[0];
    }
  }
  public void SetCharacter(Character2 character)
  {
    currentCharacter=character;
  }
}
