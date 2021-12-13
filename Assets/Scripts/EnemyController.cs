using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] protected Animator animEnemy;
    [SerializeField] protected float enemySpeed = 2.6f;
    protected Rigidbody rbEnemy;
    protected float range = 4f;
    protected Vector3 playerDirection;
    protected Vector3 posInPlayer;
    protected float rbDrag = 6f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jugador");       
        //Busca al player con el nombre de el game object "Jugador"
        posInPlayer = player.GetComponent<Transform>().position;
        rbEnemy = GetComponent<Rigidbody>();
        animEnemy.SetBool("isWalking",false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void FixedUpdate() 
    {
    }

    protected void ControlDrag()
    {
        rbEnemy.drag = rbDrag;
    }
    protected void LookAtPlayer()                                                        //Funcion para Solo Mirar al PLayer
    {
        rbEnemy.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0 ,playerDirection.z));
    }

    protected void ChasePlayer(){                                                    // El enemigo seguira al player en un rango definido desde Inspector
     
        playerDirection = GetplayerDirection();
        rbEnemy.AddForce(playerDirection.normalized * enemySpeed * 4.2f, ForceMode.Acceleration);
    }

    protected Vector3 GetplayerDirection(){
        return player.transform.position - transform.position;
    }

}
