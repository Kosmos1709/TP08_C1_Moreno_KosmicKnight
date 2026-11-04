using UnityEngine;

public class ActiveProyectileScript : AbstractPickeable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mele"))
        {
            ActivationProyectile();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActivationProyectile();
            Destroy(gameObject);
        }
    }
}
