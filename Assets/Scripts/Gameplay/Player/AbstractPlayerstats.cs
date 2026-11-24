using UnityEngine;

public abstract class AbstractPlayerstats : MonoBehaviour
{
    // Warning: health, Damage, JumpForce, speed y Keys son public y cualquier clase los muta (AbstractPickeable lo hace con Keys).
    // Pasalos a [SerializeField] private y exponé properties o métodos (AddKey, AddDamage) para modificarlos.
    public int health = 7;
    public int Damage = 1;
    public int JumpForce = 5;
    public int speed = 5;
    public int Keys = 0;
    public float RaycastDistance = 0.1f;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] public LayerMask floorLayer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public bool isGrounded;
    // Bug: MovimentPlayer declara su propio Start() y Update(), así que Unity nunca ejecuta estos dos métodos privados de la base.
    // Ni rb = GetComponent ni las escrituras al PlayerSO corren. Hacelos protected virtual y llamá base.Start()/base.Update() desde la hija.
    void Start()
    {
        Keys = 0;
        // Error: el flujo con el ScriptableObject está invertido (D1). El SO debería ser la fuente de los valores iniciales
        // y el MonoBehaviour leerlos (health = playerSO.health), no al revés. Además los valores reales quedan hardcodeados en esta clase y en la escena.
        playerSO.health = health;
        playerSO.Damage = Damage;
        playerSO.JumpForce = JumpForce;
        playerSO.speed = speed;
        playerSO.Keys = Keys;
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }
    private void Update()
    {
        playerSO.health = health;
        playerSO.Damage = Damage;
        playerSO.JumpForce = JumpForce;
        playerSO.speed = speed;
        playerSO.Keys = Keys;
    }
}
