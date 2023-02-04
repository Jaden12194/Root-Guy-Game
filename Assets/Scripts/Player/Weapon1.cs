using UnityEngine;
using System.Collections;

public class Weapon1 : MonoBehaviour {
    
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    //====================================================================================

    // Update is called once per frame
    void Update() {
    
        cooldownTimer += Time.deltaTime;
        //Single Press for Single Fire Weapons
        if (Input.GetButtonDown("Fire1")) {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                Shoot();
            }
        }
    }

//====================================================================================

    //projectile shooting
    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

//end
}
