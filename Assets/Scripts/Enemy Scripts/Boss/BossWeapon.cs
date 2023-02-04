using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{

    public GameObject misslePrefab;
    public Transform firePoint;

    public void shootMissle() {
        Instantiate(misslePrefab, firePoint.position, firePoint.rotation);
    }
}
