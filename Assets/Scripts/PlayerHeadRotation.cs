using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadRotation : MonoBehaviour
{
    [SerializeField] private float ejeY = 0f;
    [SerializeField] private float ejeX = 0f;

    void Update()
    {
        Rotar();
    }

    void Rotar()
    {
        ejeY += Input.GetAxis("Mouse Y");
        ejeX += Input.GetAxis("Mouse X");
        ejeY = Mathf.Clamp(ejeY, -20, 15);
        Quaternion angulo = Quaternion.Euler(-ejeY * 1.5f, ejeX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, angulo, 1 * Time.deltaTime);
    }
}
