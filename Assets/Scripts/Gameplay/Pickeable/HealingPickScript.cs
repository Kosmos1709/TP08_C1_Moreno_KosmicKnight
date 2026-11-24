using UnityEngine;

public class HealingPickScript : AbstractPickeable
{
    // Suggestion: el mismo par OnTriggerEnter2D/OnCollisionEnter2D está copiado en los cuatro pickups. Movelo a AbstractPickeable con un método abstract Apply().
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
