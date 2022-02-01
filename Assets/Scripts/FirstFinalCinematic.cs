using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstFinalCinematic : MonoBehaviour, ICinematic
{
    [SerializeField] Transform ToLook;
    [SerializeField] Transform ToGo;
    public static event Action OnFirstFinal;

    public void OnStartCinematic()
    {
        StartCoroutine(FirstScene());
    }

    IEnumerator FirstScene()
    {
        ControlPlayer.Instance.LookAt(ToLook);
        ControlPlayer.Instance.MoveTo(ToGo);
        yield return new WaitForSeconds(5);
        OnFirstFinal?.Invoke();
        Debug.Log("A");
    }
}
