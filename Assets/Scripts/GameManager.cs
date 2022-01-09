using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singlenton<GameManager>
{
    [SerializeField] GameObject UIInHouse;
    [SerializeField] GameObject UICinematicText;
    [SerializeField] GameObject enParticles;
    [SerializeField] GameObject onPauseMenu;
    [SerializeField] public bool onPause = false;

   
    private void Start()
    {
        Time.timeScale = 1;
        onPauseMenu.SetActive(false);
    }
    private void OnEnable()
    {
        FirstCinematic.OnFirstCinematic += FirstCinematicMethod;
        SecondCinematic.OnSecondCinematic += SecondCinematicMethod;
        FirstFinalCinematic.OnFirstFinal += FirstFinal;
        EnemyController.OnPlayerDeath += EndGame;
    }
    private void OnDisable()
    {
        FirstCinematic.OnFirstCinematic -= FirstCinematicMethod;
        SecondCinematic.OnSecondCinematic -= SecondCinematicMethod;
        FirstFinalCinematic.OnFirstFinal -= FirstFinal;
        EnemyController.OnPlayerDeath -= EndGame;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(onPause == false)
            {
                onPause = true;
            } else if (onPause == true)
            {
                onPause = false;

            }
            OnPause(onPause);
        }
    }
    public void OnPause(bool pause)
    {
        if(pause == true)
        {
            onPauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        } else if(pause == false)
        {
            onPauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void FirstCinematicMethod()
    {
        UIInHouse.SetActive(false);
        StartCoroutine(BlinkEffect());
        FirstCinematic.OnFirstCinematic -= FirstCinematicMethod;
    }
    public void SecondCinematicMethod()
    {
        enParticles.SetActive(false);
        UIInHouse.SetActive(true);
        SecondCinematic.OnSecondCinematic -= SecondCinematicMethod;
    }
    public void FirstFinal()
    {
        SceneManager.LoadScene("FirstFinalScene", LoadSceneMode.Single);
        Debug.Log("A");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    IEnumerator BlinkEffect()
    {
        float time = 15;
        while (time > 0)
        {
            UICinematicText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            UICinematicText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            time -= 0.5f;
        }
        UICinematicText.SetActive(false);
    }
}
