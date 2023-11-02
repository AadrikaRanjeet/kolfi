using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BatAttack : MonoBehaviour
{
public float speed;
public float lineOfSite;
public float moveLimit,fireRate,nextfireTime;
//[SerializeField] private Transform[] enemy;
public GameObject enemy;
public GameObject fireball;
public GameObject fireballParent;//place to spawn fireballs
public LayerMask enemylayers;

public static BatAttack Instance;
public int RangedAttackDamage;

[SerializeField] private Transform[] waypoints; // Define waypoints in the Inspector
    public float moveSpeed = 3.0f;
    public float waypointSwitchDistance = 0.1f;

    private int currentWaypointIndex = 0;
void Start()
{
  //  enemy=GameObject.FindGameObjectsWithTag("enemy").transform;
  GameObject[] waypointsobject=GameObject.FindGameObjectsWithTag("waypoints");

  // Create an array of Transforms to store the found waypoints
   waypoints = new Transform[waypointsobject.Length];

   // Assign the Transforms from the found GameObjects to the waypoints array
        for (int i = 0; i < waypointsobject.Length; i++)
        {
            waypoints[i] = waypointsobject[i].transform;
        }
   Instance=this;
}
void Update()
{
    Attack();
    Move();
}

void Move()
{
    // Calculate the direction to the current waypoint
    Vector2 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;

    // Move the bat towards the current waypoint
    transform.Translate(direction * moveSpeed * Time.deltaTime);

    // Check if the bat has reached the current waypoint
    if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < waypointSwitchDistance)
    {
        // Increment the waypoint index to move to the next waypoint
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}


void Attack()
{
   //detect enemies and then perform attack in else statement 
    Collider2D [] hitEnemies=Physics2D.OverlapCircleAll(transform.position ,lineOfSite,enemylayers);
    foreach(Collider2D Enemy in hitEnemies)
    {
        enemy=Enemy.gameObject;
      float distanceFromEnemy=Vector2.Distance( enemy.transform.position,transform.position);
   if(distanceFromEnemy<lineOfSite&&distanceFromEnemy>moveLimit)
   {
    transform.position=Vector2.MoveTowards(this.transform.position,enemy.transform.position,speed*Time.deltaTime);
   }
   else if(distanceFromEnemy<moveLimit&&nextfireTime<Time.time)
   {
    GameObject fireball1= Instantiate(fireball,fireballParent.transform.position,Quaternion.identity);
     //accessing the script 
               EnemyHealth health=Enemy.GetComponent<EnemyHealth>();

               if(health!=null)
               {
                 health.TakeDamage(RangedAttackDamage);
               }
   //getting access of the script attached to fireball
    SnailAttackandMove script=fireball1.GetComponent<SnailAttackandMove>();

    //set the target for the fireball 
    script.SetTarget(enemy.transform);
     nextfireTime =Time.time+fireRate;
   }
    }

}
private  void OnDrawGizmosSelected()
{
    Gizmos.DrawWireSphere(transform.position,lineOfSite);
      Gizmos.DrawWireSphere(transform.position,moveLimit);
}
}
