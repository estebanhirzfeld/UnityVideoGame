using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors: MonoBehaviour, IClicked
{
    [SerializeField] private Key.KeyType keyType = Key.KeyType.nothing;
    [SerializeField] public bool openned;
    [SerializeField] bool canOpen;
    [SerializeField] Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnClickAction()
   {
        if(KeyManager.Instance.ContainsKey(keyType) || keyType == Key.KeyType.nothing || canOpen == true)
        {
            canOpen = true;
            if (openned == true)
            {
                anim.SetBool("IsOpen", false);
                openned = false;
            }
            else if (openned == false)
            {
                anim.SetBool("IsOpen", true);
                openned = true;
            }
        }
        else if (keyType != Key.KeyType.nothing && !KeyManager.Instance.ContainsKey(keyType))
        {
            HelpTextManager.Instance.ShowText("You don´t have the key to open this door");
        }
    }
}
