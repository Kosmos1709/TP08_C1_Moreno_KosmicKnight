using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int health;
    public int Damage;
    public int JumpForce;
    public int speed;
    public int Gold;
}
