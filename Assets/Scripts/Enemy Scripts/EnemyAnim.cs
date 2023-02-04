using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float Xrange;
    [SerializeField] private float Yrange;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask Player;
    private float cooldownTimer = Mathf.Infinity;
    public GameObject projectilePrefab;
    private Animator anim;

    public Transform firePoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight()) //Attacks if the enemy is within the red box ("sight") around the enemy
        {
            if (cooldownTimer >= attackCooldown)
            {
                if (gameObject == null)
                {
                    return;
                }
                else 
                {
                    cooldownTimer = 0;
                    anim.SetTrigger("IsShooting");
                    Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                }
            }
        }
    }
    private bool PlayerInSight() //Defines the parameters of the enemy sight.
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * Xrange * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * Xrange, boxCollider.bounds.size.y*Yrange, boxCollider.bounds.size.z),
            0, Vector2.left, 0, Player);
        return hit.collider != null;
    }
    private void OnDrawGizmos() //No gameplay function but visually shows a red box for what counts as sight...
                                //KEEP NOTE: If you change the parameters above, try to make the same changes below.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * Xrange* transform.localScale.x * colliderDistance,
            new Vector3 (boxCollider.bounds.size.x * Xrange, boxCollider.bounds.size.y*Yrange, boxCollider.bounds.size.z));
    }
}