using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    private float startDelay = 1.0f;
    private float repeatRate = 1.5f;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Player").GetComponent<GameManager>();
        InvokeRepeating("LaunchFire", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameOver)
            CancelInvoke(nameof(LaunchFire));
    }
    void LaunchFire()
    {
        Instantiate(fire, transform.position, fire.transform.rotation); // launch from enemy's pos
    }
}
