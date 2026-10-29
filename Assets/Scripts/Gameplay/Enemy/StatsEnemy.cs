using UnityEngine;

public class StatsEnemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField] public int health = 2;
    [SerializeField] public bool isDead = false;
    [SerializeField] private AudioSource deadSound;
    [SerializeField] public float countDown = 1f;
    void Start()
    {
        isDead = false;
        health = 2;
        animator = GetComponent<Animator>();
        animator.SetBool("Dead", false);
    }

    //recibir daño del jugador 
    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        if (health <= 0)
        {
            Die();
        }

    }
    //Funcion para morir agregare count para la animacion de muerte 
    void Die()
    {
        countDown = 1f;
        animator.SetBool("Dead", true);
        deadSound.Play();

    }
    //activa el couldown para desaparecer tras morir, lego lo modifico para la animacion de muerte
    void Update()
    {
        if (health <= 0)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Destroy(gameObject);
            }
            health = 0;
            isDead = true;

        }
    }
}
