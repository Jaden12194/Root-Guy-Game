using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;//where player will spawn after death or fall.

    private void Awake()
    {
        lastCheckPointPos = transform.position;
        if(instance == null)//makes sure there is only one instance of GameMaster.
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
