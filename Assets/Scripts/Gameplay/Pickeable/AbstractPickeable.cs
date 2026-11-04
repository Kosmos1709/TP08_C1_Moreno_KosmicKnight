using UnityEngine;

public class AbstractPickeable : MonoBehaviour
{
    // creare funciones para alterar las stats del jugador llamandolas desde aqui, como abstract
    //  entonces solo se tendra que llamar a la funcion de este script y no tocar el script del jugador
    [SerializeField] public bool ActiveProyectile=false;
    
    


    public void ActivationProyectile()//    [LISTO]
    {
        ActiveProyectile = true;
    }

    public void ActivationDobleJump()//    [LISTO]
    {
        MovimentPlayer movimentPlayer = FindObjectOfType<MovimentPlayer>();
        movimentPlayer.DobleJumpPickeable = true;
    }

    public void ActivationMoreHeal()
    {
        HealBarPlayer healBarPlayer = FindObjectOfType<HealBarPlayer>();
        healBarPlayer.HealBar.value += 1;
    }
    public void GetKeys()
    {
        //add keys en otro script
        Destroy(gameObject);
    }

}
