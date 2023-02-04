using UnityEngine;
using Pathfinding;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController2D : MonoBehaviour {
    private Animator anim;
    [System.Serializable]
   
   //Enemy Stats Controller
    public class EnemyStats {
        public int Health = 100;
    }
    public EnemyStats stats = new EnemyStats();
    public int fallBoundary = -20;

//====================================================================================

    void Update () {
        if (transform.position.y <= fallBoundary) {
                DamageEnemy(99999999); }
    }

//=====================================================================================

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

//====================================================================================

    public void DamageEnemy (int damage) {
        stats.Health -= damage;
        if(stats.Health <= 0) {
            anim.SetBool("IsDead", true);
            Die(this);
        }
    }

//====================================================================================

    void Die (EnemyController2D enemy) {
        Destroy(enemy.gameObject, 1);
        if (enemy.CompareTag("BossEnemy")) {
            SceneManager.LoadScene(0);
        }
    }

//====================================================================================

//end
}
