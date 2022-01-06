using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singlenton<GameManager>
{
    [SerializeField] GameObject UIInGame;
    [SerializeField] GameObject UICinematicText;

   
    private void Start()
    {
        FirstCinematic.OnFirstCinematic += FirstCinematicMethod;
        SecondCinematic.OnSecondCinematic += SecondCinematicMethod;
        EnemyController.OnPlayerDeath += EndGame;
    }

    public void FirstCinematicMethod()
    {
        UIInGame.SetActive(false);
        StartCoroutine(BlinkEffect());
        FirstCinematic.OnFirstCinematic -= FirstCinematicMethod;
    }
    public void SecondCinematicMethod()
    {
        UIInGame.SetActive(true);
        SecondCinematic.OnSecondCinematic -= SecondCinematicMethod;
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
