using UnityEngine;

public class MovimentPlayer :  AbstractPlayerstats
{
    [Header("Components")]
    [SerializeField] private AtackPlayer atackPlayer;
    [SerializeField] private HealBarPlayer healbarplayer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private AudioSource WinSound;
    [SerializeField] private AudioSource WalkSound;

    [Header("Variables")]
    // Warning: [SerializeField] public es redundante y deja el campo mutable desde afuera (horizonLook, DobleJumpPickeable, DobleJump, LocalscaleVar).
    // Usá [SerializeField] private y una property de solo lectura donde otra clase lo necesite.
    [SerializeField] public float horizonLook;
    [SerializeField] public bool DobleJumpPickeable = false;
    [SerializeField] public bool DobleJump = false;
    public float LocalscaleVar;
    private bool playingWinSound = false;
    void Start()
    {
        healbarplayer = GetComponent<HealBarPlayer>();
        atackPlayer = GetComponent<AtackPlayer>();
    }
    private void Playwin()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
        WinSound.Play();
        playingWinSound = true;
    }
    //la anide a una animacion de caminata
    public void Walking()
    {
        WalkSound.Play();
    }
    void Update()
    {
        // Suggestion: el 3 es un número mágico (también en la línea 42). Llevá la cantidad de llaves para ganar a un ScriptableObject del nivel.
        if (Keys>=3 && !playingWinSound)
        {
            Playwin();
        }
        if (healbarplayer.isDead == false  && Keys < 3)
        {
            float horizontalX = Input.GetAxis("Horizontal");

            Vector2 position = transform.position;

            // Warning: el jugador tiene Rigidbody2D y lo movés escribiendo transform.position en Update, lo que pelea con la física (atraviesa paredes, jitter).
            // Seteá rb.linearVelocity = new Vector2(horizontalX * speed, rb.linearVelocity.y) en FixedUpdate.
            transform.position = new Vector2(position.x + horizontalX * speed * Time.deltaTime, position.y);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RaycastDistance, floorLayer);
            isGrounded = hit.collider != null;

            // salto del personaje
            if ( Input.GetKeyDown(KeyCode.Space))
            {
                //consulto si agarro el item y toco el piso, para poder reiniciar el salto doble
                if (DobleJumpPickeable && isGrounded)
                {
                    DobleJump = true;
                }
                //si esta en el piso puede saltar sin mas
                if (isGrounded )
                {
                    // Error: el salto no reproduce ningún sonido, y la consigna pide que todas las acciones del jugador estén animadas y con sonido (J6, S3).
                    // Agregá un AudioSource de salto y llamalo acá y en el doble salto de la línea 68.
                    rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                }
                //y si no esta en el piso y tiene activo el salto doble, puede saltar una vez mas
                else if (DobleJump )
                {
                    rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    DobleJump = false;
                }
            }

            // condicionales para animaciones
            // Suggestion: los nombres de parámetros del Animator son strings mágicos. Cachealos con Animator.StringToHash en campos static readonly.
            animator.SetFloat("SpeedAnimator", Mathf.Abs(horizontalX));
            animator.SetFloat("SpeedJump", rb.linearVelocity.y);
            animator.SetBool("Grounded", isGrounded);
            animator.SetBool("attacking", atackPlayer.attacking);


            // cambiar direccion de la mira del personaje 
            horizonLook = Input.GetAxisRaw("Horizontal");
            LocalscaleVar = transform.localScale.x;
           
            if (horizonLook > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (horizonLook < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        

    }
    
    //esto dibuja el raycast par el dev
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * RaycastDistance);
    }
}
