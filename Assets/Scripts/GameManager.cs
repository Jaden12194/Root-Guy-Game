using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Image healthBar;
    public float health = 10.0f;
    public int hitDamage = 1;
    public bool isGameOver;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("green").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
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
        if (health > 0)  // to avoid -ve values.
        {
            health -= hitDamage;
            healthBar.fillAmount = health / 10;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // gets the active scene, we dont have to remember scene names
    }
}
