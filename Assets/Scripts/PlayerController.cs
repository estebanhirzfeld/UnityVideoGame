using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 2.3f;
    [SerializeField] private float ejeX = 0f;
    [SerializeField] private float stamina = 10;
    [SerializeField] private GameObject tablet;

    private Rigidbody rbPlayer;
    float ejeHorizontal;
    float ejeVertical;
    Vector3 moveDirection;
    float rbDrag = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rbPlayer.freezeRotation = true;
        tablet = GameObject.Find("Tablet");
    }

    // Update is called once per frame
    void Update()
    {
        TabletMostrar();
        Correr();
        Rotar();
        Inputs();
        ControlDrag();
    }
    void FixedUpdate()
    {
        Avanzar();
    }

    void Inputs()
    {
        ejeHorizontal = Input.GetAxisRaw("Horizontal");
        ejeVertical = Input.GetAxisRaw("Vertical");
        moveDirection = transform.forward * ejeVertical + transform.right * ejeHorizontal;
    }
    void ControlDrag()
    {
        rbPlayer.drag = rbDrag;
    }
    private void Avanzar()
    {
        rbPlayer.AddForce(moveDirection.normalized * velocidadMovimiento * 10, ForceMode.Acceleration);
    }

    void Rotar()
    {
        ejeX += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler(0, ejeX, 0);
        transform.rotation = angulo;
    }

    void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= 2.7f * Time.deltaTime;
            if (stamina <= 0)
            {
                velocidadMovimiento = 2f;
                stamina = 0;
                return;
            }
            velocidadMovimiento = 2.9f;
        } else
        {
            if (stamina >= 10)
            {
                velocidadMovimiento = 2.5f;
                stamina = 10;
                return;
            }
            stamina += 2f * Time.deltaTime;
            velocidadMovimiento = 2f;

         }        

    }

    void TabletMostrar()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!tablet.activeInHierarchy)
            {
                tablet.SetActive(true);
            }
            else if (tablet.activeInHierarchy)
            {
                tablet.SetActive(false);
            }
        }
    }

}
