using UnityEngine;

public class PickupSound : MonoBehaviour
{
    [SerializeField] public AudioSource AudioPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {
            AudioPick.Play();
        }
    }
}
