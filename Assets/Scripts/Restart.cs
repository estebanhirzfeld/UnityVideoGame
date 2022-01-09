using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        } else if(Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync("InGame", LoadSceneMode.Single);
        }
    }
}
