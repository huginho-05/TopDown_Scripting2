using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeySO key;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory inventory =
            other.GetComponent<PlayerInventory>();

        if (inventory == null)
            return;

        inventory.AddKey(key);

        Debug.Log("Recogida llave: " + key.keyId);

        Destroy(gameObject);
    }
}
