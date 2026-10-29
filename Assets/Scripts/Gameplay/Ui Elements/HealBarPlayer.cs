using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealBarPlayer : MonoBehaviour
{
    [SerializeField] private Slider HealBar;
    [SerializeField] private float ForceKnockback = 1f;
    [SerializeField] private Rigidbody2D rb;


    private void Awake()
    {
        HealBar.value = 7f;
        rb = GetComponent<Rigidbody2D>();
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
 

}
