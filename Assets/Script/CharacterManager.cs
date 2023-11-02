using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    public Text CharName;
    public SpriteRenderer sprite;
    private int SelectedOption=0;// will keep track of which character is selected

  
    void Start()
    {
        if(!PlayerPrefs.HasKey("SelectedOption"))
        {
            SelectedOption=0;
        }
        else
        {
            Load();
        }
        UpdatedCharacter(SelectedOption);
    }
   public void NextOption()
{
    SelectedOption++;
    if(SelectedOption >=characterDatabase.CharacterCount)
    {
        SelectedOption=0;
    }
    UpdatedCharacter(SelectedOption);
    Save();
}
public void BackOption()
{
    SelectedOption--;
    if(SelectedOption<0)
    {
        SelectedOption=characterDatabase.CharacterCount-1;
    }
    UpdatedCharacter(SelectedOption);
    Save();
}
  private void UpdatedCharacter(int SelectedOption)
  {
    CharacterSelection character=characterDatabase.GetCharacter(SelectedOption);
    sprite.sprite=character.characterSprite;
    CharName.text=character.characterName;
  }  

  private void Load()
  {
    SelectedOption=PlayerPrefs.GetInt("SelectedOption");
  }
  private void Save()
  {
    PlayerPrefs.SetInt("SelectedOption",SelectedOption);
  }
  public void ChangeScene(int scene)
{
    SceneManager.LoadScene(scene);
}}
