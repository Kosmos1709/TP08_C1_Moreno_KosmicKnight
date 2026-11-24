using UnityEngine;

public class AtackPlayer : MonoBehaviour

{
    //damage 1
    // Warning: el estado del power up vive en el pickup de la escena, que se destruye al agarrarlo (ActiveProyectileScript.cs:10).
    // Si la referencia queda sin asignar, la línea 47 tira NullReferenceException. Guardá un bool privado en el jugador y que el pickup lo active.
    [SerializeField] public ActiveProyectileScript activeProyectileScript;
    [Header("Components")]
    [SerializeField] private GameObject ProyectilPrefab;
    [SerializeField] private Transform FirePointRight;
    [SerializeField] private MovimentPlayer movimentPlayer;
    [Header("Attack Settings")]
    [SerializeField] private float CDAtack = 0.5f;
    [SerializeField] private float timeatack = 0.5f;
    [SerializeField] public bool attacking = false;
    [Header("Sounds")]
    [SerializeField] private AudioSource MeleSound;
    [SerializeField] private AudioSource ProyectilSound;
    void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    void Update()
    {
        
        CDAtack -= Time.deltaTime;
        timeatack -= Time.deltaTime;
        if (CDAtack < 0)
        {
            CDAtack = 0;
        }
        if (timeatack < 0)
        {
            timeatack = 0;
        }
        //ataque a Mele
        if (Input.GetMouseButtonDown(0)&& CDAtack<= 0 )
        {
            Atacking ();
            MeleSound.Play();
            // Suggestion: pisás CDAtack con un 0.5f literal, así el valor del inspector solo vale para el primer ataque. Separá cooldown (serializado) y timer (privado).
            CDAtack = 0.5f;
                timeatack = 0.5f;
            // Suggestion: esta llamada nunca dispara, porque timeatack se acaba de poner en 0.5f y ShootInAtackPlayer exige timeatack <= 0.
            // El disparo real lo hace el evento de Atack.anim. Sacala o documentá la intención.
            ShootInAtackPlayer();

        }
        //ataque distancia
        if (Input.GetMouseButtonDown(1) && !attacking && activeProyectileScript.ActiveProyectile)
        {
            Atacking();
            MeleSound.Play();
        }
    }
    public void Atacking()
    {
        attacking = true;
        gameObject.layer = LayerMask.NameToLayer("Mele");

    }
    public void StopAtacking()
    {
        attacking = false;
        gameObject.layer = LayerMask.NameToLayer("Player");

    }
    public void ShootInAtackPlayer()
    {
        if (timeatack <= 0)
        {
            ShootingPlayer BulletObject = Instantiate(ProyectilPrefab, FirePointRight.position, Quaternion.identity).GetComponent<ShootingPlayer>();
            if (movimentPlayer.LocalscaleVar < 0)
            {
                BulletObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (movimentPlayer.LocalscaleVar > 0)
            {
                BulletObject.transform.localScale = new Vector3(1, 1, 1);
            }
            BulletObject.Shoot(Mathf.Sign(movimentPlayer.LocalscaleVar));
            ProyectilSound.Play();
        }
    }
    public void Start()
    {
        movimentPlayer = GetComponent<MovimentPlayer>();
    }
}
