using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Vector3 posInicial;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = door.GetComponent<Transform>().position;
        Debug.Log(posInicial);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Juego terminado! Felicidades");
            CloseDoor();
        }
    }

    void CloseDoor()
    {
        door.GetComponent<Transform>().position = posInicial;
    }
}
