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
                Time.timeScale = 1f;
            }
        }
    }
}
