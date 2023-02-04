using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;
    public float rotateSpeed = 200f;
    public Transform target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
		Destroy(gameObject);

        if (hitInfo.CompareTag("BossEnemy")) {
            Debug.Log("FUCK its hitting the boss");
        }
        else if (hitInfo.CompareTag("Bullet")) {
            Debug.Log("SHIT its hitting itself");
        }

	}
}