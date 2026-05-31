using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerFlashlight : MonoBehaviour
{
    [Header("Linterna")]
    [SerializeField] private Light flashlight;
    [SerializeField] private Collider flashlightCollider;
    [SerializeField] private GameObject flashlightChild;

    [SerializeField] private int maxCharges;
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

    // Disparar linterna
    private void FireFlashlight()
    {
        if (isFlashing) return;
        if (currentCharges <= 0) return;

        currentCharges--;
        UpdateUI();

        StartCoroutine(FlashRoutine());
    }

    // Comportamiento linterna
    private IEnumerator FlashRoutine()
    {
        isFlashing = true;

        flashlight.enabled = true;
        flashlightCollider.enabled = true;
        flashlightChild.SetActive(true);

        yield return new WaitForSeconds(flashDuration);

        flashlight.enabled = false;
        flashlightCollider.enabled = false;
        flashlightChild.SetActive(false);

        isFlashing = false;
    }

    // Matar fantasma
    private void OnTriggerEnter(Collider other)
    {
        GhostEnemy ghost = other.GetComponentInParent<GhostEnemy>();

        if (ghost != null && flashlight.enabled)
        {
            ghost.Die();
        }
    }

    // Recoger pila añade una recarga
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
