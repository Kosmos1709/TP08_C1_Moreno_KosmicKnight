using UnityEngine;
using UnityEngine.UI;

public class WinLoseUI : MonoBehaviour
{
    [SerializeField] private Button Restart;
    [SerializeField] private Button BackMenu;

    void Awake()
    {
        Restart.onClick.AddListener(OnButtonRestartClick);
        BackMenu.onClick.AddListener(OnButtonBackMenuClick);
    }
    private void OnDestroy()
    {
        Restart.onClick.RemoveAllListeners();
        BackMenu.onClick.RemoveAllListeners();
    }

    private void OnButtonRestartClick()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    private void OnButtonBackMenuClick()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
