using UnityEngine;

public class InteractionsEnemy : abstractEnemy
{
    private StatsEnemy statsenemy;
    [SerializeField] private Animator animator;
    [SerializeField] private bool Change;
    [SerializeField] private bool AtackBoll;

    void Start()
    {
        statsenemy = GetComponent<StatsEnemy>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mele") )
        {
            MovimentPlayer player = FindObjectOfType<MovimentPlayer>();
            statsenemy.TakeDamage(player.Damage);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if ( collision.gameObject.layer == LayerMask.NameToLayer("Proyectile"))
        {
            MovimentPlayer player = FindObjectOfType<MovimentPlayer>();
            statsenemy.TakeDamage(player.Damage);
        }
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
      //esta condicional solo ejecuta atacar cuando sea verdadero
        if (AtackBoll && !statsenemy.deadSound.isPlaying)
        {
            statsenemy.StartAtack();
        }
        //Chekea si coliciona con una pared para cambiar de direccion 
        if (Change)
        {
            //bajo la ubicacion del raycast para que pueda tocar al player
            Vector2 origen = (Vector2)transform.position + Vector2.down * 1;
            RaycastHit2D hit = Physics2D.Raycast(origen, Vector2.left, RaycastDistance, floorLayer);
            Wall = hit.collider != null;

            //este raycast corrobora si coliciona con el player para ejecutar el ataque
        RaycastHit2D hitplayer = Physics2D.Raycast(origen, Vector2.left, RaycastDistance, PlayerLayer);
        AtackBoll = hitplayer.collider != null;
        }
        else
        {
            Vector2 origen = (Vector2)transform.position + Vector2.down * 1;

            RaycastHit2D hit = Physics2D.Raycast(origen, Vector2.right, RaycastDistance, floorLayer);
            Wall = hit.collider != null ;

            //este raycast corrobora si coliciona con el player para ejecutar el ataque
        RaycastHit2D hitplayer = Physics2D.Raycast(origen, Vector2.right, RaycastDistance, PlayerLayer);
        AtackBoll = hitplayer.collider != null;
        }

        if (Wall)
        {
            speed *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            Change = !Change;
        }
        //movimiento constante______ primero pasa si esta vivo, luego corrobora que no este en una animacion como "atack" o "hit"
        if (statsenemy.isDead == false )
        {
            if (statsenemy.CanWalk==true)
            {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

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
