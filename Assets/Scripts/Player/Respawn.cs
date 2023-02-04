using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    
    public GameObject fallDetector;
    private GameMaster gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        //moves fallDetector according to where player moves.
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }
    //method for checking if player hits fallDetector.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking to see if the colisition is for falldetector.
        if (collision.tag == "FallDetector")
        {
            //makes player go back to respawn point.
            transform.position = gm.lastCheckPointPos;
        } 
    }
}
