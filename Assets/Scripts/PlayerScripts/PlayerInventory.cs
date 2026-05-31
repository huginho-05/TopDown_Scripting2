using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    private HashSet<KeySO> collectedKeys = new();

    public void AddKey(KeySO key)
    {
        collectedKeys.Add(key);
    }

    public bool HasKey(KeySO key)
    {
        return collectedKeys.Contains(key);
    }
}
