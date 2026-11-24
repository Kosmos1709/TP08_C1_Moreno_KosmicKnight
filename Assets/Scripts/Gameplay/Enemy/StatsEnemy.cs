// Suggestion: using Unity.VisualScripting no se usa. Borralo.
using Unity.VisualScripting;
using UnityEngine;

public class StatsEnemy : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;

    [Header("Variables")]
    // Error: health no se muestra en ninguna UI. El Golem Prefab no tiene Slider ni barra de vida y la consigna lo pide (E2).
    // Además health e isDead son public: pasalos a private con property de lectura.
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
    // Error: la muerte solo activa la animación y el sonido. La consigna pide partículas al morir (E3) y el Golem Prefab no tiene ParticleSystem.
    // Instanciá un prefab de partículas acá.
    void Die()
    {
        animator.SetBool("Die", true);
        deadSound.Play();
        // Warning: GameObject.Find("Player") con string mágico cada vez que muere un enemigo. Serializá la referencia o usá colliderPlayer, que está declarado y no se usa.
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
    // Bug: TakeDamage no chequea isDead. Golpear al golem ya muerto vuelve a reproducir Hit, HitSound y llama Die() otra vez (deadSound se reinicia).
    // Agregá if (isDead) return; al principio.
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
        // Bug: el ataque reproduce deadSound, el mismo clip de la muerte. Usá un AudioSource propio para el ataque (E4).
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
