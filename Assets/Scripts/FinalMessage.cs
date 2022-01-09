using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalMessage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] messages;
    void Start()
    {
        int index;
        index = Random.Range(0, messages.Length);
        text.text = messages[index];
    }


}
