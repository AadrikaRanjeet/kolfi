using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
  public enum SpawnState{SPAWNING , COUNTING ,WAITING};//defining the datastrucutre
  [System.Serializable]

    //creating a custom class
    public class Wave
   {
       public string name;
       //reference to prefab that we want to instantiate
       public Transform enemy;
       public int count;
       public float rate;//spawn rate

      

   }

   public Wave [] waves;
   private int nextWave=0;//index of the wave that we going to be creating next
   
   public float TimeBtwWaves=5f;
   private float waveCountdown;
   private float searchCountdown=1f;
    [SerializeField] private  Transform [] spawnPoints;
    public float Wavecount=3;
   private SpawnState state=SpawnState.COUNTING;


   void Start()
   {
   GameObject[] spawnPointObj=GameObject.FindGameObjectsWithTag("spawnpoint");
   spawnPoints=new Transform[spawnPointObj.Length];
    waveCountdown=TimeBtwWaves;
    // Assign the Transforms from the found GameObjects to the waypoints array
        for (int i = 0; i < spawnPointObj.Length; i++)
        {
            spawnPoints[i] = spawnPointObj[i].transform;
        }
    if(spawnPoints.Length==0)
    {
      Debug.LogError("No Spawn points referenced");
    }
   }

   void Update()
   {
    if(state==SpawnState.WAITING)
    {
        //will check if enemies are still alive
        if(!enemyIsAlive())
        {
         Debug.Log("No Enemies");
            //start next round of spawning
           waveCompeleted();
          
        }
        else
        {
            return;
        }
          if(Wavecount==0)
        {
          Invoke("Die",3f);
          Debug.Log("Destroyed");
        }
    }
   
      if(waveCountdown<=0)
     {
        if(state!=SpawnState.SPAWNING)
        {
            // Start Spawning state
               StartCoroutine(SpawnWave(waves[nextWave]));
   
        }
     }
     else
     {
        waveCountdown -=Time.deltaTime;
     }

   }
   void waveCompeleted()
   {
     Debug.Log("wave Completed");
     state= SpawnState.COUNTING;
     waveCountdown=TimeBtwWaves;
     if(nextWave +1 >waves.Length-1)
     {
      
          nextWave=0;
        Debug.Log("completed all waves");
      
        
     }
     else
     {
        nextWave++;
     }
    
   }
    bool enemyIsAlive()
   {
     searchCountdown-=Time.deltaTime;
     if(searchCountdown <=0)
     {
        searchCountdown=1f;
       if(GameObject.FindGameObjectWithTag("enemy")==null)
     {
        return false;
     }
     }
     
     return true;
   }
   IEnumerator SpawnWave(Wave _wave)
   {
    Debug.Log("Spawning state:"+_wave.name);
     state=SpawnState.SPAWNING;
     //spawning
     if(Wavecount>0)
     {
              for(int i=0;i<_wave.count;i++)
     {

      
          SpawnEnemy( _wave.enemy);
        yield return new WaitForSeconds(1f/_wave.rate);
      
       
     }
      Wavecount--;
     }
 
     state=SpawnState.WAITING;
   

      //yield break;
   }
   void SpawnEnemy(Transform _enemy)
   {
     //Spawn Enemy
     Transform _sp= spawnPoints[Random.Range(0,spawnPoints.Length)];
     Instantiate(_enemy,_sp.position,_sp.rotation);
     Debug.Log("Spawaning enemy"+_enemy.name);
   }
   void Die()
    {
          Destroy(gameObject);
    }
}
