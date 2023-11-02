using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
  //accessing the ally gameobject
  [SerializeField] private GameObject[] ally;
 private int allyIndex;
public void ChangeAlly(int index)
{
   for(int i=0;i<ally.Length;i++)
   {
     ally[i].SetActive(false);//diable rest of allies
   }
   this.allyIndex=index;//save the selected character index
    ally[index].SetActive(true);
}
public void StartGame()
{
    SceneManager.LoadScene(1);
    PlayerPrefs.SetInt("AllyIndex",allyIndex);
}
}