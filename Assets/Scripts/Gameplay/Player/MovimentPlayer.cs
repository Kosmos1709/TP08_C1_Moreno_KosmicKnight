using UnityEngine;

public class MovimentPlayer :  AbstractPlayerstats
{
    [Header("Components")]
    [SerializeField] private AtackPlayer atackPlayer;
    [SerializeField] private HealBarPlayer healbarplayer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private AudioSource WinSound;

    [Header("Variables")]
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
    void Update()
    {
        if (Keys>=3 && !playingWinSound)
        {
            Playwin();
        }
        if (healbarplayer.isDead == false  && Keys < 3)
        {
            float horizontalX = Input.GetAxis("Horizontal");

            Vector2 position = transform.position;

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
