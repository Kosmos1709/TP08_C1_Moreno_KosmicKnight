using UnityEngine;
using TMPro;
public class KeyCount : MonoBehaviour
{
    [SerializeField] private MovimentPlayer moviment;
    // Suggestion: el campo se llama lifeCountText pero muestra llaves, y el texto se rearma cada frame en Update. Renombralo y actualizalo solo cuando cambie Keys.
    [SerializeField] private TextMeshProUGUI lifeCountText;
  
    void Update()
    {
        lifeCountText.text = "x " + moviment.Keys.ToString("00");
    }
}
