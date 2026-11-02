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
    [SerializeField] public AudioSource deadSound;
    [SerializeField] private AudioSource HitSound;


    void Start()
    {
        CanWalk = true;
        colliderThisGO = GetComponent<Collider2D>();
        isDead = false;
        
        animator = GetComponent<Animator>();
        animator.SetBool("Die", false);
    }

    //Funcion para morir agregare count para la animacion de muerte 
    void Die()
    {
        animator.SetBool("Die", true);
        deadSound.Play();
        Physics2D.IgnoreCollision(colliderThisGO, GameObject.Find("Player").GetComponent<Collider2D>());
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
    
    //recibir daño del jugador 
    public void TakeDamage(float damage)
    {
        CanWalk = false;
        animator.SetBool("Hit",true);
        HitSound.Play();
        health -= (int)damage;
        if (health <= 0)
        {
            Die();
        }

    }
    public void stopHit()
    {
        //agregar bool de golpe
        CanWalk = true;
        animator.SetBool("Hit", false);

    }
    public void StartAtack()
    {
        CanWalk = false;
        animator.SetBool("Atack", true);
        deadSound.Play();
    }
    public void StopAttack()
    {
        CanWalk = true;
        animator.SetBool("Atack", false);
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
