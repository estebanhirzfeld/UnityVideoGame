using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebas : MonoBehaviour, ICinematic
{
    public void OnStartCinematic()
    {
        ControlPlayer.Instance.LookAt(gameObject.transform);
    }
}
