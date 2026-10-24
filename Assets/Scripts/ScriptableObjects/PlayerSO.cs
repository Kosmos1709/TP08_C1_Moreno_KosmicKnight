using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int health;//AbstractPlayerstats
    public int Damage;//AbstractPlayerstats
    public int JumpForce; //AbstractPlayerstats
    public int speed; //AbstractPlayerstats
    public int Gold; //AbstractPlayerstats
}
