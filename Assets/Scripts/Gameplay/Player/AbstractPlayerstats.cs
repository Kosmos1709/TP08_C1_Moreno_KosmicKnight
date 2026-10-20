using UnityEngine;

public abstract class AbstractPlayerstats : MonoBehaviour
{
    public int health = 100;
    public int Damage = 10;
    public int JumpForce = 5;
    public int speed = 5;
    public int Gold = 0;
    public float RaycastDistance = 0.1f;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] public LayerMask floorLayer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public bool isGrounded;
    void Start()
    {
        playerSO.health = health;
        playerSO.Damage = Damage;
        playerSO.JumpForce = JumpForce;
        playerSO.speed = speed;
        playerSO.Gold = Gold;
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }
    private void Update()
    {
        playerSO.health = health;
        playerSO.Damage = Damage;
        playerSO.JumpForce = JumpForce;
        playerSO.speed = speed;
        playerSO.Gold = Gold;
    }
}
