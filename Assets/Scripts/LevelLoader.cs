using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.CompareTag("Player")) {
    //        SceneManager.LoadScene(2);
    //    }
    //}
    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().name == "Cutscene 1")
            SceneManager.LoadScene("Level 1");
        else if (SceneManager.GetActiveScene().name == "Level 1")
            SceneManager.LoadScene("Level 2");
        else if (SceneManager.GetActiveScene().name == "Level 2")
            SceneManager.LoadScene("Cutscene 2");
        else if (SceneManager.GetActiveScene().name == "Cutscene 2")
            SceneManager.LoadScene("Overworld2");
        else if (SceneManager.GetActiveScene().name == "Overworld2")
            SceneManager.LoadScene("Level 4");
        else if (SceneManager.GetActiveScene().name == "Level 4")
            SceneManager.LoadScene("Cutscene 1");
    }
}
