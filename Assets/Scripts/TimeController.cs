using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{

    protected TimeController() { }
    public static TimeController Instance;
    private const float REAL_SECONDS_PER_DAY = 300f;
    [SerializeField] private TextMeshPro clockText;
    public float day;
    



    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_DAY;

        float dayNormalized = day % 1f;

        float hoursPerDay = 24f;

        string hoursString = Mathf.Floor((dayNormalized * hoursPerDay)).ToString("00");

        float minutesPerHour = 60f;

        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1) * minutesPerHour).ToString("00");

        clockText.text = hoursString + ":" + minutesString;


    }
}
