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
        // Warning: LayerMask.NameToLayer con strings mágicos ("Mele", "Invicible", "Proyectile", "Enemy", "Obstacle") en cada colisión.
        // Cachealos en Awake en campos int, o usá LayerMask serializados.
        if (collision.gameObject.layer == LayerMask.NameToLayer("Mele") )
        {
            // Warning: FindObjectOfType recorre toda la escena en cada golpe y está obsoleto en Unity 6.
            // Leé el daño desde el collider que te golpeó (collision.GetComponentInParent<MovimentPlayer>()) o serializá la referencia.
            MovimentPlayer player = FindObjectOfType<MovimentPlayer>();
            statsenemy.TakeDamage(player.Damage);
        }
        //Invicible
        if (collision.gameObject.layer == LayerMask.NameToLayer("Invicible"))
        {
            // Suggestion: el bloque de dar vuelta al enemigo está copiado 4 veces (líneas 26, 45, 54 y 95). Extraelo a un método Flip().
            speed *= -1;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            Change = !Change;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if ( collision.gameObject.layer == LayerMask.NameToLayer("Proyectile"))
        {
            // Warning: de nuevo FindObjectOfType en cada impacto de proyectil. El daño debería venir del proyectil.
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
        // Bug: no se chequea statsenemy.isDead, así que un golem muerto que todavía tiene al jugador en el raycast sigue llamando a StartAtack
        // durante la animación de muerte. Agregá && !statsenemy.isDead.
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
                    // Warning: el enemigo tiene Rigidbody2D y se mueve con transform.Translate en Update. Movelo con rb.linearVelocity en FixedUpdate.
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
