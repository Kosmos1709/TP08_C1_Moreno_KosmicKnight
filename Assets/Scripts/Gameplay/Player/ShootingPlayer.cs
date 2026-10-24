using System;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    // damage 1
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float time = 0f;
    [SerializeField] private float lifetime = 2f;


    public void Shoot( float v)
    {
        
        Vector3 dir = new Vector3(v, 0, 0).normalized;
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject);
        }
    
    }
    private void Start()
    {
        rb = GetComponent < Rigidbody2D>();

    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > lifetime)
        {
            Destroy(gameObject);
        }
    }

}
