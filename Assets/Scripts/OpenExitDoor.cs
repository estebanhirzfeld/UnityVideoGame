using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenExitDoor : MonoBehaviour
{
    float number = 0;

    private void Awake()
    {
        MissionsManager.OnCompleteAllMissions += OpenDoor;
    }
    private void OpenDoor()
    {

        while (number < 4)
        {
            Debug.Log("Anda");
            number++;
            transform.position += new Vector3(0, 1, 0);
        }

    }

}
