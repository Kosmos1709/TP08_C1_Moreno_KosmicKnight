using UnityEngine;

// Suggestion: la clase se llama abstractEnemy pero no es abstract y no sigue PascalCase. Renombrala (EnemyBase) y marcala abstract.
public class abstractEnemy : MonoBehaviour
{
    // Warning: todos los campos son [SerializeField] public, mutables desde cualquier clase. Usá [SerializeField] protected o private.
    [SerializeField] public int speed ;
    [SerializeField] public float RaycastDistance = 0.1f;
    [SerializeField] public LayerMask floorLayer;
    [SerializeField] public LayerMask PlayerLayer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public bool Wall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Suggestion: Update vacío. Unity igual lo invoca cada frame; borralo.
    void Update()
    {
        
    }
}
