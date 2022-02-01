using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameMenu.Instance.ChangeScene("MainMenu");
        } else if(Input.anyKeyDown)
        {
            GameMenu.Instance.ChangeScene("InGame");
        }
    }
}
