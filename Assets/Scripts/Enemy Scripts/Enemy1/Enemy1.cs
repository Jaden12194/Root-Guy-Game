using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class Enemy1 : MonoBehaviour
{
//====================================================================================

    //what to chase
    public Transform target;
    
    //How many times each second we will update our path
    public float updateRate = 2f;
    
    //Distance to close to player and speed that it will move
    public float stoppingDistance;
    public float speed = 200f;

    //Enemy Shooting the Player
    public GameObject projectilePrefab;
    private float weaponCooldown;
    public float rateOfFire;

    //Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //Calculated path
    public Path path;

    //AI speed per second
    public GameObject deathEffect;

    bool pathIsEnded = false;
    // distance of ai to a waypoint, for it to continue to the next one
    float nextWaypointDistance = 3;
    //current waypoint path variable
    int currentWaypoint = 0;

//====================================================================================

    void Start() {

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

//====================================================================================

    void UpdatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
//====================================================================================

    public void OnPathComplete(Path p)
    {
        //Debug.LogError("lmao" + p.error);
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

//====================================================================================

    void Shoot() {
        if (weaponCooldown <= 0) {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            weaponCooldown = rateOfFire;
        } else {
            weaponCooldown -= Time.deltaTime;
        }
    }

//====================================================================================

    void FixedUpdate()
    {

        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            pathIsEnded = true;
            return; 
        } else {
            pathIsEnded = false;
        }

        //direction to next waypoint
        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance) {
            rb.AddForce(force);
        }
        if (Vector2.Distance(transform.position, target.position) <= stoppingDistance) {
            Shoot();
        }

        float distance = (Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]));
       
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

       /* supposed to flip the enemy when it changes direction 
        if(rb.velocity.x >= 0.01f) {
            transform.Rotate(0f, 180f, 0f);
         }
        if (rb.velocity.x <= -0.01f) {
         	transform.Rotate(0f, 180f, 0f);        
        }
        */
    }

//end
}