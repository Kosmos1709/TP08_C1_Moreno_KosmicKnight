using UnityEngine;

public class ClicksInteraccion : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
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
        else
        {
            Time.timeScale = 1f;
        }
    }
}
