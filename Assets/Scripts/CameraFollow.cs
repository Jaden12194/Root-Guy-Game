using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yheight;


    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,yheight, -10f);
        transform.position = Vector3.Slerp(transform.position,newPos, FollowSpeed*Time.deltaTime);
    }
}
