using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAccion : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button BtnStart;
    [SerializeField] private Button BtnSettings;
    [SerializeField] private Button BtnCredits;
    [SerializeField] private Button BtnBack;

    [Header("Panels")]
    [SerializeField] private GameObject PanelVolume;
    [SerializeField] private GameObject PanelCredits;

    [SerializeField] private AudioSource buttonAudio;
    [SerializeField] private AudioSource BGAudio;



    private void Awake()
    {
        BtnStart.onClick.AddListener(OnButtonStartClick);
        BtnSettings.onClick.AddListener(OnButtonVolumeClick);
        BtnCredits.onClick.AddListener(OnButtonCreditsClick);
        BtnBack.onClick.AddListener(OnButtonHTPClick);


    }
    private void OnDestroy()
    {
        BtnStart.onClick.RemoveAllListeners();
        BtnSettings.onClick.RemoveAllListeners();
        BtnCredits.onClick.RemoveAllListeners();
        BtnBack.onClick.RemoveAllListeners();
    }


    private void OnButtonStartClick()
    {
        buttonAudio.Play();
        Time.timeScale = 1f;
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
    private void OnButtonHTPClick()
    {
        buttonAudio.Play();
        Debug.Log("Clickbutton HTP");
        SceneManager.LoadScene("MainMenu");
    }

}
