using UnityEngine;
using TMPro;
public class KeyCount : MonoBehaviour
{
    [SerializeField] private MovimentPlayer moviment;
    [SerializeField] private TextMeshProUGUI lifeCountText;
  
    void Update()
    {
        lifeCountText.text = "x " + moviment.Keys.ToString("00");
    }
}
