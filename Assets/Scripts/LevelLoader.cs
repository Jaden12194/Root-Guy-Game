using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadScene();
            Debug.Log("Fucking hell this shit dont work!");
        }
    }
    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().name == "Cutscene 1")
            SceneManager.LoadScene(1);
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Debug.Log("Not Cutscene 1");
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().name == "level 2")
        {
            Debug.Log("Not Level 1");
            SceneManager.LoadScene(3);
        }
        else if (SceneManager.GetActiveScene().name == "Cutscene 2")
        {
            Debug.Log("Not level 2");
            SceneManager.LoadScene(4);
        }
        else if (SceneManager.GetActiveScene().name == "Overworld2")
        {
            Debug.Log("Not Cutscene 2");
            SceneManager.LoadScene(5);
        }
        else
        {
            Debug.Log("it aint none of this shit");
        }
    }
}
