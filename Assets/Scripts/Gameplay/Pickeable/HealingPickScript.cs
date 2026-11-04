using UnityEngine;

public class HealingPickScript : AbstractPickeable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mele"))
        {
            ActivationMoreHeal();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActivationMoreHeal();
            Destroy(gameObject);
        }
    }
}
