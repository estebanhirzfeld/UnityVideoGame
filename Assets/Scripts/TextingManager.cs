using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextingManager : MonoBehaviour
{
    protected TextingManager() { }
    public static TextingManager Instance;

    public bool talking = false;

    public GameObject panel;
    public TextMeshProUGUI textPanel;

    int lineIndex;
    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }
    public void Talk(Texting conversation)
    {
        if (!talking)
        {
            StartTexting(conversation);
        }
    }
    void NextLine(Texting conversation)
    {
        if (lineIndex < (conversation.conversationLines.Length - 1))
        {
            lineIndex++;
            StartCoroutine(WriteLine(conversation));
        }
        else
        {
            EndTexting();
        }
    }
    void StartTexting(Texting conversation)
    {
        panel.SetActive(true);
        talking = true;
        lineIndex = 0;
        StartCoroutine(WriteLine(conversation));
    }
    void EndTexting()
    {
        lineIndex = 0;
        talking = false;
        textPanel.text = string.Empty;
        panel.SetActive(false);
    }
    IEnumerator WriteLine(Texting conversation)
    {
        textPanel.text = string.Empty;
        foreach (char ch in conversation.conversationLines[lineIndex].ConversationText)
        {
            textPanel.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3.5f);
        if (textPanel.text == conversation.conversationLines[lineIndex].ConversationText)
        {
            NextLine(conversation);
        }
    }

}
