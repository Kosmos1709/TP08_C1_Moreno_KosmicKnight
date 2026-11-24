using UnityEngine;

public class ClicksInteraccion : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private HealBarPlayer healbarplayer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPause.SetActive(!MenuPause.activeSelf);
        }
        if (MenuPause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        if (!MenuPause.activeSelf)
        {
            if (healbarplayer.isDead)
            {
                //necesito que no ejecute nada cuando el jugador muera, entonces asi solos se ejecuta la funcion
                //de Healbarplayer donde se detiene el tiempo y sse abre el panel de perder, y no se ejecuta el else que vuelve a poner el tiempo en 1
            }
            else
            {
                // Bug: este else pone timeScale en 1 cada frame si el jugador no está muerto, y pisa el Time.timeScale = 0 de MovimentPlayer.Playwin (MovimentPlayer.cs:27).
                // Con el Win Panel abierto el juego sigue corriendo. Consultá también si ganó, o manejá el timeScale en un solo lugar.
                Time.timeScale = 1f;
            }
        }
    }
}
