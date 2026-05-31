using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    private void OnTriggerEnter(Collider other)
    {
        door.PlayerEntered(other);
    }

    private void OnTriggerExit(Collider other)
    {
        door.PlayerExited(other);
    }
}
