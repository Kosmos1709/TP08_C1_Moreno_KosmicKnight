using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Error: la clase MenuAccion está en un archivo que se llama distinto (MenuAcctions.cs). Unity lo compila pero tira un warning.
// Renombrá el archivo o la clase para que coincidan.
public class MenuAccion : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button BtnContinue;
    [SerializeField] private Button BtnStart;
    [SerializeField] private Button BtnSettings;
    [SerializeField] private Button BtnCredits;
    [SerializeField] private Button BtnBack;

    [Header("Panels")]
    [SerializeField] private GameObject PanelVolume;
    [SerializeField] private GameObject PanelCredits;
    [SerializeField] private GameObject MenuPanel;

    [SerializeField] private AudioSource buttonAudio;
    [SerializeField] private AudioSource BGAudio;



    private void Awake()
    {
        BtnContinue.onClick.AddListener(OnButtonContinueClick);
        BtnStart.onClick.AddListener(OnButtonStartClick);
        BtnSettings.onClick.AddListener(OnButtonVolumeClick);
        BtnCredits.onClick.AddListener(OnButtonCreditsClick);
        BtnBack.onClick.AddListener(OnButtonHTPClick);
        Time.timeScale = 1f;

    }
    private void OnDestroy()
    {
        BtnContinue.onClick.RemoveAllListeners();
        BtnStart.onClick.RemoveAllListeners();
        BtnSettings.onClick.RemoveAllListeners();
        BtnCredits.onClick.RemoveAllListeners();
        BtnBack.onClick.RemoveAllListeners();
    }

    private void OnButtonContinueClick()
    {
        buttonAudio.Play();
        Time.timeScale = 1f;
        MenuPanel.SetActive(false);
    }
    private void OnButtonStartClick()
    {
        buttonAudio.Play();
        Time.timeScale = 1f;
        // Suggestion: nombres de escena como strings ("Gameplay", "MainMenu") repetidos acá y en WinLoseUI.cs. Centralizalos en constantes.
        SceneManager.LoadScene("Gameplay");
    }
    private void OnButtonVolumeClick()
    {
        buttonAudio.Play();
        Debug.Log("Clickbutton Volume");
        PanelVolume.SetActive(!PanelVolume.activeSelf);
    }
    private void OnButtonCreditsClick()
    {
        buttonAudio.Play();
        Debug.Log("Clickbutton Credits");
        PanelCredits.SetActive(!PanelCredits.activeSelf);

    }
    // Suggestion: OnButtonHTPClick está conectado a BtnBack y carga MainMenu. El nombre no describe lo que hace; renombralo a OnButtonBackClick.
    private void OnButtonHTPClick()
    {
        buttonAudio.Play();
        Debug.Log("Clickbutton HTP");
        SceneManager.LoadScene("MainMenu");
    }

}
