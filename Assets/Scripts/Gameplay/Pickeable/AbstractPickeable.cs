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
        // Warning: FindObjectOfType en cada pickup (líneas 19, 25 y 30). Obtené el componente del collider que tocó el pickup y pasalo como parámetro.
        MovimentPlayer movimentPlayer = FindObjectOfType<MovimentPlayer>();
        movimentPlayer.DobleJumpPickeable = true;
    }

    public void ActivationMoreHeal()//    [LISTO]
    {
        HealBarPlayer healBarPlayer = FindObjectOfType<HealBarPlayer>();
        healBarPlayer.HealBar.value += 1;
    }
    public void GetKeys()//    [LISTO]
    {
        MovimentPlayer movimentPlayer = FindObjectOfType<MovimentPlayer>();
        movimentPlayer.Keys += 1;
        // Suggestion: GetKeys destruye el objeto y KeyScript vuelve a llamar Destroy(gameObject) justo después. Dejá la destrucción en un solo lugar.
        Destroy(gameObject);
    }

}
