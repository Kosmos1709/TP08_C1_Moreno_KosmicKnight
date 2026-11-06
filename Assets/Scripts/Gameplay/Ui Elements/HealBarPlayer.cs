using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealBarPlayer : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] public Slider HealBar;
    [SerializeField] private GameObject LosePanel;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource AudioLose;

    [Header("Variables")]
    [SerializeField] private float ForceKnockback = 1f;
    [SerializeField] public bool isDead;
    [SerializeField] private Transform transformpositionplayer;


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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("void"))
        {
            HealBar.value -= 1;
            transform.position = new Vector3(transformpositionplayer.position.x, transformpositionplayer.position.y, transformpositionplayer.position.z);
        }
    }
    public void Update()
    {
        //evitar que la barra de vida se pase de los limites
        if (HealBar.value>7)
        {
            HealBar.value = 7;
        }
        //evitar que la barra de vida se pase de los limites
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
        LosePanel.SetActive(true);
        AudioLose.Play();
    }
}
