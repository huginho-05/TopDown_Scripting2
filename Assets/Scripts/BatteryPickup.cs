using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFlashlight flashlight = FindFirstObjectByType<PlayerFlashlight>();

            if (flashlight != null)
            {
                flashlight.AddCharge(1);
                Destroy(gameObject);
            }
        }
    }
}
