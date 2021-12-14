using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRunner : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jugador");
        posInPlayer = player.GetComponent<Transform>().position;
        rbEnemy = GetComponent<Rigidbody>();
        animEnemy.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        ControlDrag();
    }

    private void FixedUpdate()
    {
        ChasePlayer();
        LookAtPlayer();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Has muerto! Vuelve a comenzar");
            SceneManager.LoadScene("Game");
        }
    }
}
