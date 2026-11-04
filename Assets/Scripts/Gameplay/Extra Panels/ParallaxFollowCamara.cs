using UnityEngine;

public class ParallaxFollowCamara : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float Speed = 2f;
    [SerializeField] private float EndPoint;
    [SerializeField] private float StartPoint;

    private float lastX;

    void Start()
    {
        lastX = player.position.x;
    }

    void LateUpdate()
    {
        // 1 = jugador va a la derecha, -1 = izquierda, 0 = quieto
        float direccion = 0;
        if (player.position.x > lastX) direccion = 1;
        else if (player.position.x < lastX) direccion = -1;
        lastX = player.position.x;

        // Como es hijo de la cámara usamos localPosition
        Vector3 pos = transform.localPosition;
        pos.x -= direccion * Speed * Time.deltaTime;

        // Si se pasa de un límite, vuelve por el otro
        if (pos.x <= EndPoint) pos.x = StartPoint;
        else if (pos.x >= StartPoint) pos.x = EndPoint;

        transform.localPosition = pos;
    }
}
