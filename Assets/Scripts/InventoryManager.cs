using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager: MonoBehaviour
{
    // Start is called before the first frame update
    protected InventoryManager() { }

    public static InventoryManager Instance;

    public Inventory inventory;

    private void Awake()
    {
        Instance = this;
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        inventory.slot.enabled = false;
    }
    public void AddItem(ItemKey key)
    {
                inventory.isFull = true;
                inventory.slot.sprite = key.sprite;
                inventory.slot.enabled = true;
    }
    public void RemoveItem()
    {
        inventory.isFull = false;
        inventory.slot.sprite = null;
        inventory.slot.enabled = false;
    }
}
