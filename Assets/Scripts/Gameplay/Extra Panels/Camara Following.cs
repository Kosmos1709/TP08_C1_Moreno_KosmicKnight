using UnityEngine;

public class CamaraFollowing : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float CamaraVelocity = 0.125f;
    [SerializeField] private Vector3 movement;

    private void LateUpdate()
    {
        Vector3 GoalPosition = player.position + movement;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, GoalPosition, CamaraVelocity);
        transform.position = smoothedPosition;
    }
}
