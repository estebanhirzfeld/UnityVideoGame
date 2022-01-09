using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitToEnd : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time;
    void Start()
    {
        StartCoroutine(ShowFinal(time));
    }
    IEnumerator ShowFinal(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("FinalText", LoadSceneMode.Single);

    }
        
}
