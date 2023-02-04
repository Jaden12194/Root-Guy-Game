using UnityEngine;
using System.Collections;

public class Weapon1Projectile : MonoBehaviour
{
    public float speed = 130;
    public int damage = 50;

    public Rigidbody2D rigidBody2D;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        Destroy(gameObject, 1);
    }

//====================================================================================

    void OnTriggerEnter2D(Collider2D hitInfo) //Bullet recognizes that it hit something
    {
        EnemyController2D enemy = hitInfo.GetComponent<EnemyController2D>();
        if (hitInfo.CompareTag("Player"))
        {
            return;
        }
        if (enemy != null) {
            enemy.DamageEnemy(damage); //Enemy takes damage
        }
        Destroy(gameObject);
    }

//end
}
