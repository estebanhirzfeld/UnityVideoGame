using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    protected KeyManager() { }
    // Start is called before the first frame update
    [SerializeField] public Key.KeyType currentKey = Key.KeyType.nothing;
    public static KeyManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void AddKey(Key.KeyType key)
    {
        currentKey = key;
    }
    public void RemoveKey()
    {
        currentKey = Key.KeyType.nothing;
    }
    public bool ContainsKey(Key.KeyType key)
    {
        if (currentKey == key)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
