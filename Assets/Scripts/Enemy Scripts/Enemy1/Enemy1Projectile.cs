using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Projectile : MonoBehaviour
{

    public float speed = 70;
    public int damage = 50;

    private Transform player;
    private Vector2 target;

//====================================================================================

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y); 
    }

//====================================================================================

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);        
        Destroy(gameObject, 1);
        //instantiate an effect for the lazer projectile impact, (explodes when the time is up)
    }

//====================================================================================

    void OnTriggerEnter2D(Collider2D hitInfo) { //Bullet recognizes that it hit something
        
        //doesnt work i think
        CharacterController2D character = hitInfo.GetComponent<CharacterController2D>();
        if (character != null) {
            Debug.Log("owie");
        }

        //doesnt work i think
        if(hitInfo.CompareTag("Player")) {
            Debug.Log("glunked");
            Destroy(gameObject);
        }

    }
}
