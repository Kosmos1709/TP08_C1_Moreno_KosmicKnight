using UnityEngine;

public class AtackPlayer : MonoBehaviour

{
    //damage 1

    [SerializeField] private GameObject ProyectilPrefab;
    [SerializeField] private Transform FirePointRight;
    [SerializeField] private MovimentPlayer movimentPlayer;
    [SerializeField] private float CDAtack = 0.2f;
    [SerializeField] public bool attacking = false;



    void Update()
    {
        
        CDAtack -= Time.deltaTime;

        Debug.Log(movimentPlayer.horizonLook);
        //ataque a distancia
        if (Input.GetMouseButtonDown(1))
        {
         ShootingPlayer BulletObject = Instantiate(ProyectilPrefab, FirePointRight.position, Quaternion.identity).GetComponent<ShootingPlayer>();
            if (movimentPlayer.LocalscaleVar < 0)
            {
                BulletObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (movimentPlayer.LocalscaleVar > 0)
            {
                BulletObject.transform.localScale = new Vector3(1, 1, 1);
            }
            BulletObject.Shoot(Mathf.Sign(movimentPlayer.LocalscaleVar));
        }
        //ataque cuerpo a cuerpo
        if (Input.GetMouseButtonDown(0) && !attacking && movimentPlayer.isGrounded)
        {
            Atacking();
        }
    }
    public void Atacking()
    {
        attacking = true;
    }
    public void StopAtacking()
    {
        attacking = false;
    }
    public void Start()
    {
        movimentPlayer = GetComponent<MovimentPlayer>();
    }
}
