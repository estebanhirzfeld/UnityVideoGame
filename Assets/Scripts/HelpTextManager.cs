using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpTextManager : MonoBehaviour
{
    protected HelpTextManager() { }
    public static HelpTextManager Instance;
    [SerializeField] TextMeshProUGUI textPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowText(string text)
    {
        StartCoroutine(TimedShowed(text));
    }

    IEnumerator TimedShowed(string text)
    {
        textPanel.text = text;
        yield return new WaitForSeconds(4);
        textPanel.text = string.Empty;
    }
}
