using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float health = 10.0f;
    public int hitDamage = 1;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("green").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DealDamage();
        }
    }
    public void DealDamage()
    {
        health -= hitDamage;
        healthBar.fillAmount = health / 10;
    }
}
