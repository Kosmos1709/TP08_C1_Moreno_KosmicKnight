using UnityEngine;

// Error: la clase CamaraFollowing está en un archivo que se llama distinto ("Camara Following.cs", con espacio). Unity lo compila pero tira un warning.
// Renombrá el archivo o la clase para que coincidan.
public class CamaraFollowing : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float CamaraVelocity = 0.125f;
    [SerializeField] private Vector3 movement;

    private void LateUpdate()
    {
        Vector3 GoalPosition = player.position + movement;
        // Warning: Lerp con un factor fijo por frame hace que la cámara siga más rápido a más FPS. Multiplicá por Time.deltaTime o usá Vector3.SmoothDamp.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, GoalPosition, CamaraVelocity);
        transform.position = smoothedPosition;
    }
}
