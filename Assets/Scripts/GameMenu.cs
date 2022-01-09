using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void DesPause()
    {
        GameManager.Instance.onPause = false;
        GameManager.Instance.OnPause(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
