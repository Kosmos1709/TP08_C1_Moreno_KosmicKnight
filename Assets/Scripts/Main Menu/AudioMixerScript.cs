using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audiomixer;
    [SerializeField] private VolumenValues volumenValues;

    [SerializeField] private Slider VMaster;
    [SerializeField] private Slider VBackground;
    [SerializeField] private Slider VSfx;
    [SerializeField] private Slider VUi;


    private void Awake()
    {
        VMaster.onValueChanged.AddListener(SliderMaster);
        VBackground.onValueChanged.AddListener(SliderBackground);
        VSfx.onValueChanged.AddListener(SliderSFX);
        VUi.onValueChanged.AddListener(SliderUI);
    }


    private void OnDestroy()
    {

        VMaster.onValueChanged.RemoveAllListeners();
        VBackground.onValueChanged.RemoveAllListeners();
        VSfx.onValueChanged.RemoveAllListeners();
        VUi.onValueChanged.RemoveAllListeners();
    }
    void Start()
    {
        VMaster.value = volumenValues.MasterVolumeobject;
        VBackground.value = volumenValues.BackgroundVolumeobject;
        VSfx.value = volumenValues.SFXVolumeobject;
        VUi.value = volumenValues.UIVolumeobject;
    }



    /// ///////////////////////////////
    private void SliderMaster(float value)
    {
        audiomixer.SetFloat("Master", value);
        volumenValues.MasterVolumeobject = value;
    }
    private void SliderBackground(float value)
    {
        audiomixer.SetFloat("Background", value);
        volumenValues.BackgroundVolumeobject = value;

    }
    private void SliderSFX(float value)
    {
        audiomixer.SetFloat("SFX", value);
        volumenValues.SFXVolumeobject = value;
    }
    private void SliderUI(float value)
    {
        audiomixer.SetFloat("UI", value);
        volumenValues.UIVolumeobject = value;
    }

}
