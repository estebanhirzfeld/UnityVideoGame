using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInLocker : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject player;
    [SerializeField] GameObject casilleroInterior;
    [SerializeField] GameObject casilleroSalida;
    float coldDown = 1.5f;
    public bool hidden = false;

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void LateUpdate()
    {
        if (coldDown > 0)
        {
            coldDown -= Time.deltaTime;
        }
        if (hidden == true)
        {
            player.transform.position = casilleroInterior.transform.position + new Vector3(0, 0.4f, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (coldDown > 0)
                {
                    return;
                }
                if (hidden == false)
                {
                    player.transform.localScale = new Vector3(0.9f, 1f, 0.9f);
                    player.transform.position = casilleroInterior.transform.position + new Vector3(0, 0.4f, 0);
                    coldDown = 1.5f;
                    hidden = true;
                }
                else if (hidden == true)
                {
                    player.transform.localScale = new Vector3(2f, 2f, 2f);
                    player.transform.position = casilleroSalida.transform.position;
                    coldDown = 1.5f;
                    hidden = false;
                }

            }
        }
    }
}
