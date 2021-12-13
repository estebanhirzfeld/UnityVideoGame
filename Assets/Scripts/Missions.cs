using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Missions : MonoBehaviour
{
    public static event Action<int> OnComplete;
    public static event Action<int, float> OnCompleting;
    [SerializeField] GameObject missionLight;
    [SerializeField] int numeroMision;
    public bool missionComplete = false;
    float timeToComplete = 10f;


    private void Update()
    {
        if (missionComplete == false)
        {
            missionLight.GetComponent<Light>().color = new Color(1, 0, 0, 1);
        }
        else if (missionComplete == true)
        {
            missionLight.GetComponent<Light>().color = new Color(0, 1, 0, 1);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (missionComplete == false)
            {
                if (timeToComplete > 0)
                {
                    timeToComplete -= Time.deltaTime;
                    OnCompleting?.Invoke(numeroMision, timeToComplete);
                }
                else
                {
                    missionComplete = true;
                    OnComplete?.Invoke(numeroMision);
                }
            }

        }
    }
}
