using UnityEngine;

public class ExtraJumpScript : AbstractPickeable
{
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mele"))
        {
            ActivationDobleJump();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActivationDobleJump();
            Destroy(gameObject);
        }
    }
}
