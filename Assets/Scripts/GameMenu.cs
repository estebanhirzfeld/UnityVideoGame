using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    protected GameMenu() { }
    public static GameMenu Instance;
    public Animator transition;
    void Start()
    {
        Instance = this;
        transition = GetComponent<Animator>();
        StartCoroutine(LoadedScene());
    }
    public void DesPause()
    {
        GameManager.Instance.onPause = false;
        GameManager.Instance.OnPause(false);
    }
    public void StartGame()
    {
        StartCoroutine(LoadScene("InGame"));
    }
    public void ExitGame()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }
    public void ChangeScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1.3f);
        SceneManager.LoadScene(scene);
    }
    IEnumerator LoadedScene()
    {
        yield return new WaitForSecondsRealtime(1.3f);
        Time.timeScale = 1f;
    }
}
