using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCinematics : MonoBehaviour
{
    [SerializeField] GameObject UIThings;
    private void OnTriggerStay(Collider other)
    {
        if (ControlPlayer.Instance.executing != true)
        {
            StartCoroutine(OnStarting(other.gameObject));
        }
    }

    IEnumerator OnStarting(GameObject obj)
    {

            TextingComponent text = obj.GetComponent<TextingComponent>();
            ICinematic cinematic = obj.GetComponent<ICinematic>();
            if (text == null && cinematic == null)
            {
                yield break;
            }

            if (cinematic != null)
            {
                float time = obj.GetComponent<Timer>().time;
                UIThings.SetActive(false);
                ControlPlayer.Instance.executing = true;
                cinematic.OnStartCinematic();
                yield return new WaitForSeconds(time);

                ControlPlayer.Instance.executing = false;
                UIThings.SetActive(true);
            }
            else if (text != null)
            {
                ControlPlayer.Instance.executing = true;
                TextingManager.Instance.Talk(text.Lines[0]);
                ControlPlayer.Instance.executing = false;

            }
            Destroy(obj.gameObject);
  

    }
}
