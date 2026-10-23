using UnityEngine;

public class MovimentPlayer :  AbstractPlayerstats
{
    [SerializeField] private Animator animator;
    void Update()
    {
        float horizontalX=  Input.GetAxis("Horizontal");

        Vector2 position = transform.position;

        transform.position = new Vector2(position.x + horizontalX* speed * Time.deltaTime, position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RaycastDistance, floorLayer);
        isGrounded = hit.collider != null;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

        // condicionales para animaciones
            animator.SetFloat("SpeedAnimator", Mathf.Abs(horizontalX));
            animator.SetFloat("SpeedJump", rb.linearVelocity.y);
            animator.SetBool("Grounded", isGrounded);


    }
    //esto dibuja el raycast par el dev
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * RaycastDistance);
    }
}
