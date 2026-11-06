using UnityEngine;

public class KeyScript : AbstractPickeable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mele"))
        {
            GetKeys();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetKeys();
            Destroy(gameObject);
        }
    }
}
