using UnityEngine;

public class Door : MonoBehaviour
{
    public KeySO requiredKey;
    public GameObject text;

    private bool playerNear;
    private PlayerInventory playerInventory;

    private void Start()
    {
        if (text != null) text.SetActive(false);
    }

    private void Update()
    {
        if (!playerNear) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && playerInventory.HasKey(requiredKey))
            {
                OpenDoor();
            }
        }
    }

    public void PlayerEntered(Collider other)
    {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();

        if (inventory == null) return;

        playerInventory = inventory;
        playerNear = true;

        if (text != null) text.SetActive(true);
    }

    public void PlayerExited(Collider other)
    {
        PlayerInventory inventory = other.GetComponent<PlayerInventory>();

        if (inventory == null) return;

        playerNear = false;

        if (text != null) text.SetActive(false);
    }

    private void OpenDoor()
    {
        if (text != null) text.SetActive(false);

        Destroy(gameObject);
    }
}
