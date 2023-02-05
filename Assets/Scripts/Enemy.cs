using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    private float startDelay = 1.0f;
    private float repeatRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchFire", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LaunchFire()
    {
        Instantiate(fire, transform.position, fire.transform.rotation); // launch from enemy's pos
    }
}
