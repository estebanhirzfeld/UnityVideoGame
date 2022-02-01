using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetGarageKey : MonoBehaviour, IClicked
{
    public ItemKey item;
    public Inventory inventory;
    public static event Action OnGetGarageKey;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void OnClickAction()
    {
        if (inventory.isFull == true)
        {
            HelpTextManager.Instance.ShowText("Your inventory is full!");
        }
        else
        {
            KeyManager.Instance.AddKey(item.key);
            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject);
            OnGetGarageKey?.Invoke();
        }


    }
}
