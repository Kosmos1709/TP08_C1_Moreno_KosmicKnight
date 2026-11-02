using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealBarPlayer : MonoBehaviour
{
    [SerializeField] private Slider HealBar;
    [SerializeField] private float ForceKnockback = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public bool isDead;
    [SerializeField] private Animator animator;


    private void Awake()
    {
        isDead = false;
        HealBar.value = 7f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HealBar.value -= 1;
            float direction = math.sign(transform.position.x - collision.transform.position.x);
            rb.AddForce(new Vector2(direction * ForceKnockback, 3f), ForceMode2D.Impulse);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HealBar.value -= 1;
            float direction = math.sign(transform.position.x - collision.transform.position.x);
            rb.AddForce(new Vector2(direction * ForceKnockback, 3f), ForceMode2D.Impulse);
        }
    }
    public void Update()
    {
        if (HealBar.value <= 0)
        {
            HealBar.value = 0;
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        animator.SetBool("Die", isDead);
    }
    public void StopDie()
    {
        Time.timeScale = 0f;
        animator.speed = 0;
    }
}
