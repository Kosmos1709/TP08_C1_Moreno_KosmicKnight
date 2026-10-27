using UnityEngine;

public class abstractEnemy : MonoBehaviour
{
    [SerializeField] public int speed ;
    [SerializeField] public float RaycastDistance = 0.1f;
    [SerializeField] public LayerMask floorLayer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public bool Wall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}
