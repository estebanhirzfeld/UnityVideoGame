using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    protected ControlPlayer() { }
    public static ControlPlayer Instance;
    [SerializeField]public Transform player;
    [SerializeField] Transform playerHead;
    private CharacterController cc;


    public bool executing = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = this.gameObject.transform;
        playerHead = this.gameObject.transform.Find("Head");
        cc = GetComponent<CharacterController>();

    }

    public void LookAt(Transform objDir = null)
    {
        if(objDir != null)
        {
            StartCoroutine(LookingAt(objDir));
        } else
        {
           Debug.LogError("No se ha asignado ninguna direccion para observar!");
        }
    }

    public void MoveTo(Transform objDir = null)
    {
        if (objDir != null)
        {
            StartCoroutine(MovingAt(objDir));
        }

    }
    public void StopCoroutines()
    {
        StopAllCoroutines();
    }

    IEnumerator LookingAt(Transform objDir)
    {

        Quaternion target = Quaternion.LookRotation(objDir.position - playerHead.position);

        float time = 0;

        while (time < 1)
        {
            if (playerHead.rotation == target)
            {
                yield break;

            }

            playerHead.rotation = Quaternion.Lerp(playerHead.rotation, target, time);
            time = Time.deltaTime * 3;
            yield return null;
        }


    }

    IEnumerator MovingAt(Transform objDir = null)
    {
        if (objDir != null)
        {
            Vector3 target = objDir.position - player.position;
            while (target.magnitude > 0.1f)
            {
                target = objDir.position - player.position;
                cc.Move(target.normalized * 2 * Time.deltaTime);
                yield return null;
            }
        }
        if(objDir == null)
        {
            yield break;
        }
    }
}
