using UnityEngine;

public class AbstractPickeable : MonoBehaviour
{
    // creare funciones para alterar las stats del jugador llamandolas desde aqui, como abstract
    //  entonces solo se tendra que llamar a la funcion de este script y no tocar el script del jugador
    [SerializeField] public bool ActiveProyectile=false;
    [SerializeField] public bool DobleJump=false;
    
    


    public void ActivationProyectile()
    {
        ActiveProyectile = true;
        
    }

    public void ActivationDobleJump()
    {
        DobleJump = true;
        Destroy(gameObject);
    }

    public void ActivationMoreHeal()
    {
        HealBarPlayer healBarPlayer = FindObjectOfType<HealBarPlayer>();
        healBarPlayer.HealBar.value += 1;
        Destroy(gameObject);
    }
    public void GetKeys()
    {
        //add keys en otro script
        Destroy(gameObject);
    }

}
