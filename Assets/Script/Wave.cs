using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<Enemy> enemies=new List<Enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn=new List<GameObject>();

    public Transform spawnlocation;
    public int Waveduration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    void Start()
    {
        GenerateWave();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnTimer<=0)
        {
           //spawn an enemy
           if(enemiesToSpawn.Count>0)
           {
            Instantiate(enemiesToSpawn[0],spawnlocation.position,Quaternion.identity);
            enemiesToSpawn.RemoveAt(0);
            spawnTimer=spawnInterval;
           }
           else
           {
            waveTimer=0;
           }
        }
        else
        {
            spawnTimer -=Time.fixedDeltaTime;
            waveTimer -=Time.fixedDeltaTime;
        }
    }
    public void GenerateWave()
    {
       waveValue=currWave*10;
       GenerateEnemies();

       spawnInterval=Waveduration/enemiesToSpawn.Count;
       waveTimer=Waveduration;
    }
    public void GenerateEnemies()
    {
      List<GameObject> generatedEnemies=new List<GameObject>();
      while(waveValue>0)
      {
        int randEnemyId=Random.Range(0,enemies.Count);
        int randEnemyCost =enemies[randEnemyId].cost;

        if(waveValue-randEnemyCost>=0)
        {
            generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
            waveValue -=randEnemyCost;
        }
        else if(waveValue<=0)
        {
            break;
        }
      }
      enemiesToSpawn.Clear();
      enemiesToSpawn=generatedEnemies;
    }
}
[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
