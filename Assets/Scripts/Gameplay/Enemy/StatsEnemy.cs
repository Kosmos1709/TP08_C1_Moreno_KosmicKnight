using Unity.VisualScripting;
using UnityEngine;

public class StatsEnemy : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;

    [Header("Variables")]
    [SerializeField] public int health = 2;
    [SerializeField] public bool isDead = false;
    [SerializeField] public bool CanWalk;

    [Header("Colllders")]
    [SerializeField] private Collider2D colliderThisGO;
    [SerializeField] private Collider2D colliderPlayer;

    [Header("Sounds")]
    [SerializeField] private AudioSource deadSound;

    void Start()
    {
        colliderThisGO = GetComponent<Collider2D>();
        isDead = false;
        health = 2;
        animator = GetComponent<Animator>();
        animator.SetBool("Dead", false);
    }

    //recibir daño del jugador 
    public void TakeDamage(float damage)
    {
        CanWalk = false;
        animator.SetBool("Hit",true);
        health -= (int)damage;
        if (health <= 0)
        {
            Die();
        }

    }
    //Funcion para morir agregare count para la animacion de muerte 
    void Die()
    {
        animator.SetBool("Die", true);
        deadSound.Play();
        Physics2D.IgnoreCollision(colliderThisGO, colliderPlayer);
    }
    //activa el couldown para desaparecer tras morir, lego lo modifico para la animacion de muerte
    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
    }
    
    public void stopHit()
    {
        //agregar bool de golpe
        CanWalk = true;
        animator.SetBool("Hit", false);

    }

    public void StopAttack()
    {
        CanWalk = true;
        animator.SetBool("atack", false);
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
