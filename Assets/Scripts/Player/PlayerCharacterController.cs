using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{

    public CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float Gravity = -9.81f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float ejeX = 0f;
    [SerializeField] private GameObject[] keys;
    private CharacterController cc;
    public bool startedWalking = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {

        Cursor.SetCursor(default, Vector2.zero, cursorMode);
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (ControlPlayer.Instance.executing != true && GameManager.Instance.onPause != true)
        {
            Move();
            Rotate();
        }
        velocity.y += Gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(KeyManager.Instance.currentKey == Key.KeyType.nothing)
            {
               HelpTextManager.Instance.ShowText("You don´t have any key");
               return;
            }
            if(KeyManager.Instance.currentKey == Key.KeyType.first)
            {
                Instantiate(keys[0], this.transform.position - new Vector3(0, 0.96f, 0), this.transform.rotation);
            } else if (KeyManager.Instance.currentKey == Key.KeyType.second)
            {
                Instantiate(keys[1], this.transform.position - new Vector3(0, 0.96f, 0), this.transform.rotation);
            } else if (KeyManager.Instance.currentKey == Key.KeyType.three)
            {
                Instantiate(keys[2], this.transform.position - new Vector3(0, 0.96f, 0), this.transform.rotation);
            }
            else if (KeyManager.Instance.currentKey == Key.KeyType.garage)
            {
                Instantiate(keys[3], this.transform.position - new Vector3(0, 0.96f, 0), this.transform.rotation);
            }
            KeyManager.Instance.RemoveKey();
            InventoryManager.Instance.RemoveItem();
        }
    }


    void Rotate()
    {
        ejeX += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler(0, ejeX, 0);
        transform.rotation = angulo;
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;


        if (direction.magnitude >= 0.1f)
        {
            cc.Move(direction.normalized * speed * Time.deltaTime);
            if(startedWalking == false)
            {
                startedWalking = true;
                NoiseManager.Instance.IncreaseNoise(30);

            }
        }
        if (direction.magnitude == 0f)
        {
            if(startedWalking == true)
            {

                startedWalking = false;
                NoiseManager.Instance.DecreaseNoise(30);
            }
        }
    }
}