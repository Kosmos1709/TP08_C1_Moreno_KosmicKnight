using UnityEngine;

[CreateAssetMenu(fileName = "VolumenValues", menuName = "Scriptable Objects/VolumenValues")]
public class VolumenValues : ScriptableObject
{
    public float MasterVolumeobject = 0f;
    public float BackgroundVolumeobject = -18f;
    public float SFXVolumeobject = -6f;
    public float UIVolumeobject = -5f;
}
