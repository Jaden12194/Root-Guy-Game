using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}//this line makes it so health can be only set in this file but is acessable to other files
    public Vector3 respawnPoint { get; private set; }

    private Animator anim;
    private bool dead;
    private int timesDead;
    private GameMaster gm;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }


        public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth-_damage, 0,startingHealth);
        if (currentHealth > 0)
        {
            //player Hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            if (timesDead == 2)//num of lives = num+1.
            {
                SceneManager.LoadScene(0);
                Debug.Log("ive died 3 times");
            }
            if (!dead)
            {
                Debug.Log("I have Died");
                //player dead
                anim.SetTrigger("IsDead");
                //transform.position = gm.lastCheckPointPos;
                currentHealth = startingHealth;
                transform.position = gm.lastCheckPointPos;
                timesDead++;
            }
            dead = false;
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
