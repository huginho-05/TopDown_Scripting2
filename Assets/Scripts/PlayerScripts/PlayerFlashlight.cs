using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerFlashlight : MonoBehaviour
{
    [Header("Flashlight")]
    [SerializeField] private Light flashlight;
    [SerializeField] private Collider flashlightCollider;

    [SerializeField] private int maxCharges = 6;
    [SerializeField] private float flashDuration = 1f;

    [Header("UI")]
    [SerializeField] private TMP_Text batteryText;

    private int currentCharges;
    private bool isFlashing;

    private void Start()
    {
        currentCharges = maxCharges;

        flashlight.enabled = false;
        flashlightCollider.enabled = false;

        UpdateUI();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireFlashlight();
        }
    }

    private void FireFlashlight()
    {
        if (isFlashing) return;
        if (currentCharges <= 0) return;

        currentCharges--;
        UpdateUI();

        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        isFlashing = true;

        flashlight.enabled = true;
        flashlightCollider.enabled = true;

        yield return new WaitForSeconds(flashDuration);

        flashlight.enabled = false;
        flashlightCollider.enabled = false;

        isFlashing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        GhostEnemy ghost = other.GetComponentInParent<GhostEnemy>();

        if (ghost != null && flashlight.enabled)
        {
            ghost.Die();
        }
    }

    public void AddCharge(int amount)
    {
        currentCharges = Mathf.Min(currentCharges + amount, maxCharges);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (batteryText != null)
            batteryText.text = currentCharges.ToString();
    }
}
