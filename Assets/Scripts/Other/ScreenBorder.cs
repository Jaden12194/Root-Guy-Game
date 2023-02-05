using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorder : MonoBehaviour
{
    //public GameObject topRightLimitObject;
    //public GameObject bottomLeftLimitObject;
    [SerializeField] private bool IsPlayer = false;
    private Vector3 topRightLimit;
    private Vector3 bottomLeftLimit;
    public bool TouchingBorder = false;
    public bool IsTouchingSide = false;
    public bool IsTouchingVert = false;

    //private Vector2 input;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x >= topRightLimit.x || transform.position.y >= topRightLimit.y|| transform.position.y <= bottomLeftLimit.y|| transform.position.x <= bottomLeftLimit.x)
        {
            HitBorder();
            TouchingBorder = true;
        } else {
            StartCoroutine(WaitForFrame());
            TouchingBorder = false;
        }
    }
    void HitBorder()
    {
        if (IsPlayer == true)
        {
            if ((transform.position.x >= topRightLimit.x) || (transform.position.x <= bottomLeftLimit.x))
            {
                IsTouchingSide = true;
            }
            else
            {
                IsTouchingSide = false;
            }
            if ((transform.position.y > topRightLimit.y) || (transform.position.y < bottomLeftLimit.y))
            {
                IsTouchingVert = true;
            }
            else
            {
                IsTouchingVert = false;
            }
        }
    }
    IEnumerator WaitForFrame() //prevent damage from affecting the instance multiple times in one frame (a serious problem with projectile attacks)
    {
        yield return new WaitForEndOfFrame();
    }
    public void UpdateBorder()
    {
        topRightLimit = GameObject.Find("TopRight").transform.position;
        bottomLeftLimit = GameObject.Find("BottomLeft").transform.position;
    }
}
