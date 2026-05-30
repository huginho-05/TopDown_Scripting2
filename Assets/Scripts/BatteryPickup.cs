using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerFlashlight flashlight =
            other.GetComponent<PlayerFlashlight>();

        if (flashlight != null)
        {
            flashlight.AddCharge(1);
            Destroy(gameObject);
        }
    }
}
