using UnityEngine;

public class Door : MonoBehaviour
{
    public KeySO requiredKey;
    public GameObject promptText;

    private bool playerNearby;
    private PlayerInventory playerInventory;

    private void Start()
    {
        if (promptText != null)
            promptText.SetActive(false);
    }

    private void Update()
    {
        if (!playerNearby)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null &&
                playerInventory.HasKey(requiredKey))
            {
                OpenDoor();
            }
        }
    }

    public void PlayerEntered(Collider other)
    {
        PlayerInventory inventory =
            other.GetComponent<PlayerInventory>();

        if (inventory == null)
            return;

        playerInventory = inventory;
        playerNearby = true;

        if (promptText != null)
            promptText.SetActive(true);
    }

    public void PlayerExited(Collider other)
    {
        PlayerInventory inventory =
            other.GetComponent<PlayerInventory>();

        if (inventory == null)
            return;

        playerNearby = false;

        if (promptText != null)
            promptText.SetActive(false);
    }

    private void OpenDoor()
    {
        if (promptText != null)
            promptText.SetActive(false);

        Destroy(gameObject);
    }
}
