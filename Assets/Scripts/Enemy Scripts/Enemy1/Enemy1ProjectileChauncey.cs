using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1ProjectileChauncey : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage; //this was hard coded within the file and was not usable outside this class
    public Rigidbody2D rigidBody2D;
    private Vector2 target;
    private Transform player;
    //====================================================================================

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Vector2 moveDir = (player.transform.position-transform.position).normalized*speed;
        rigidBody2D.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject, 3);
    }

    //====================================================================================

    //====================================================================================

    void OnTriggerEnter2D(Collider2D collision) //Bullet recognizes that it hit something(dont use hitinfo use collision as it is more discriptive.)
    {
        EnemyController2D enemy = collision.GetComponent<EnemyController2D>();
        if (enemy != null)
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    //end
}


//========================================================================================================================================================================
//========================================================================================================================================================================
//========================================================================================================================================================================
//========================================================================================================================================================================