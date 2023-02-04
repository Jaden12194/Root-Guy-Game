using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    //Player Target
    [Header("PlayerTarget")]
    [SerializeField] Transform targetPlayer;

    //IDLE
    [Header("Idle")]
    [SerializeField] float idleMoveSpeed;
    [SerializeField] Vector2 idleMoveDirection;

    //Attack and Move
    [Header("AttackUpNDown")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;

    [Header("MissleWeapon")]
    public GameObject misslePrefab;
    public Transform firePoint;
    [SerializeField] float countDownTimeout;
    float countDown;

    //Attack Player
    /*UNUSED UNFINISED
    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    */

    //Other
    [Header("Other")]
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;

    //Check bools
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool goingUp = true;
    private bool facingLeft = true;

    //enemy Rigidbody
    private Rigidbody2D rigidBody2D;
    
    void Start() {
        countDown = countDownTimeout;
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();

        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);

        FlipTowardsPlayer();
    }

    public void IdleState() {
        //move the body
        rigidBody2D.velocity = idleMoveSpeed * idleMoveDirection;
       
        //Ground and cieling check
        if (isTouchingUp && goingUp) {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp) {
            ChangeDirection();
        }

        //Wall check
        if(isTouchingWall) {
            if(facingLeft) {
                Flip();
            }
            else if(!facingLeft) {
                Flip();
            }
        }
    }

    //physical attack, changes movement of boss to mix up what the player must dodge
    //attackupNdown
    public void AttackState() {
        //Ground and cieling check
        if (isTouchingUp && goingUp) {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp) {
            ChangeDirection();
        }

        //Wall check
        if(isTouchingWall) {
            if(facingLeft) {
                Flip();
            }
            else if(!facingLeft) {
                Flip();
            }
        }

        //move the body
        rigidBody2D.velocity = attackMoveSpeed * attackMoveDirection;

        //Shoot the player once every 3 seconds
        if (countDown == countDownTimeout)
        {
            ShootMissle();
        }
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDown = countDownTimeout;
        }
    }

    public void ShootMissle() {
        Instantiate(misslePrefab, firePoint.position, firePoint.rotation);
    }

    //physical attack, charges at the player
    /* UNUSED
    public void AttackPlayer() {
        playerPosition = targetPlayer.position - transform.position;
        playerPosition.Normalize();
        rigidBody2D.velocity = playerPosition * attackPlayerSpeed;
    }
    */

    //up and down direction changes when he gets too close to the cieling
    void ChangeDirection() {
         goingUp = !goingUp;
         idleMoveDirection.y *= -1;
         attackMoveDirection *= -1;
    }

    void Flip () {
        facingLeft = !facingLeft;
        idleMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    void FlipTowardsPlayer() {
        float playerDirection = targetPlayer.position.x - transform.position.x;

        if (playerDirection > 0 && facingLeft) {
            Flip();
        }
        else if (playerDirection < 0 && !facingLeft) {
            Flip();
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
    }

//end
}
