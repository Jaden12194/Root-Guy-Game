using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    private float xRange = 14.0f;
    private float yRange = 5.5f;
    private Rigidbody2D fireRb;
    private GameObject player;
    public Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fireRb = GetComponent<Rigidbody2D>();
        lookDirection = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        fireRb.AddForce(lookDirection * speed);
        if (transform.position.x < -xRange || transform.position.x > xRange || transform.position.y < -yRange || transform.position.y > yRange)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
