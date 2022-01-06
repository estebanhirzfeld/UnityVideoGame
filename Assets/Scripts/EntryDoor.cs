using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryDoor : MonoBehaviour, IClicked
{
        [SerializeField] public bool openned = true;
        [SerializeField] Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            anim.SetBool("IsOpen", true);
        GetGarageKey.OnGetGarageKey += OpenDoor;
        }

        public void OnClickAction()
        {
                if (openned == true)
                {
                    anim.SetBool("IsOpen", false);
                    openned = false;
                }
        }
    private void OpenDoor()
    {
        if(TimeController.Instance.day >= 1)
        {
            anim.SetBool("IsOpen", true);
            openned = true;
        }
    }
}
