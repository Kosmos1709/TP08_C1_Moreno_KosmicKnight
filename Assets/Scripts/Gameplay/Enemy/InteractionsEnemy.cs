using UnityEngine;

public class InteractionsEnemy : abstractEnemy
{
    private StatsEnemy statsenemy;
    [SerializeField] private Animator animator;
    [SerializeField] private bool Change;
    
    void Start()
    {
        statsenemy = GetComponent<StatsEnemy>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            speed *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            Change = !Change;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            speed *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            Change = !Change;

        }
    }
    void Update()
    {
        //Chekea si coliciona con una pared para cambiar de direccion 
        if (Change)
        {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, RaycastDistance, floorLayer);
        Wall = hit.collider != null;

        }
        else
        {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, RaycastDistance, floorLayer);
        Wall = hit.collider != null ;

        }

        if (Wall)
        {
            speed *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            Change = !Change;
        }
        //movimiento constante 
        if (statsenemy.isDead == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Change)
        {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * RaycastDistance);
        }
        else
        {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * RaycastDistance);

        }
    }
}
