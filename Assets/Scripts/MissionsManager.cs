using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MissionsManager : MonoBehaviour
{
    [SerializeField] TextMeshPro[] textsTablet;
    [SerializeField] int missionsCompleted = 0;
    [SerializeField] bool[] missionsBoolCheck = new bool[4];
    public static event Action OnCompleteAllMissions;
    private bool called = false;

    private void Awake()
    {
        Missions.OnCompleting += CompletingAMission;
        Missions.OnComplete += CompleteAMission;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < textsTablet.Length; i++)
        {
            TextMeshPro texto = textsTablet[i].GetComponent<TextMeshPro>();
            texto.fontSize = 0.06f;
            texto.text = "Tarea_" + (i + 1)+ " Incompleta";
            texto.color = new Color(1, 0, 0, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (missionsCompleted == 4 && called == false)
        {
            called = true;
            OnCompleteAllMissions?.Invoke();
            Missions.OnComplete -= CompleteAMission;
            Missions.OnCompleting -= CompletingAMission;
        }
    }

    private void CompleteAMission(int numMission)
    {
        if(!missionsBoolCheck[numMission - 1] == true)
        {
            textsTablet[numMission - 1].GetComponent<TextMeshPro>().text = "Tarea_" + numMission + " Completada";
            textsTablet[numMission - 1].GetComponent<TextMeshPro>().color = new Color(0, 1, 0, 1);
            textsTablet[numMission - 1].GetComponent<TextMeshPro>().fontSize = 0.06f;
            missionsCompleted += 1;
            missionsBoolCheck[numMission - 1] = true;
        }

    }
    private void CompletingAMission(int numMission, float timeToComplete)
    {
        float timeMission = Mathf.Floor(timeToComplete);
        textsTablet[numMission - 1].GetComponent<TextMeshPro>().text = "Tarea_" + numMission + " Completando(" + timeMission + ")";
        textsTablet[numMission - 1].GetComponent<TextMeshPro>().fontSize = 0.057f;
    }
}
