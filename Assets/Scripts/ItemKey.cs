using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItem", menuName = "ItemKey", order = 1)]
public class ItemKey : ScriptableObject
{
    public Sprite sprite;
    public Key.KeyType key;
}
