using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawnAfterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] ally;
     [SerializeField] private GameObject waveSpawnerAfterAlly;
     [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        LoadAlly();
        player=GameObject.FindWithTag("Player");
    }
    private void LoadAlly()
    {
        int Allyindex=PlayerPrefs.GetInt("AllyIndex");
        Instantiate(ally[Allyindex],player.transform.position,Quaternion.identity);
         Instantiate(waveSpawnerAfterAlly,transform.position,Quaternion.identity);
    }
}
