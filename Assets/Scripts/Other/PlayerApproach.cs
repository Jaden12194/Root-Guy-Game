using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerApproach : MonoBehaviour
{
    [SerializeField] private LayerMask Player;
    private Animator anim;
    [SerializeField] private float Xrange;
    [SerializeField] private float Yrange;
    [SerializeField] private float colliderDistance;

    [SerializeField] private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSight()){
            anim.SetBool("IsNear", true);
        }
        else
        {
            anim.SetBool("IsNear", false);
        }
    }
    private bool PlayerInSight() //Defines the parameters of the enemy sight.
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * Xrange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * Xrange, boxCollider.bounds.size.y * Yrange, boxCollider.bounds.size.z),
            0, Vector2.left, 0, Player);
        return hit.collider != null;
    }
    private void OnDrawGizmos() //No gameplay function but visually shows a red box for what counts as sight...
                                //KEEP NOTE: If you change the parameters above, try to make the same changes below.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * Xrange * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * Xrange, boxCollider.bounds.size.y * Yrange, boxCollider.bounds.size.z));
    }
}
