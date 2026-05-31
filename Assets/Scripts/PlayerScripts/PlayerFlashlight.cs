using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerFlashlight : MonoBehaviour
{
    [Header("Flashlight")]
    [SerializeField] private Light flashlight;
    [SerializeField] private float range = 15f;
    [SerializeField] private int maxCharges = 6;
    
    [SerializeField] private TMP_Text batteryText;

    private int currentCharges;

    private void Start()
    {
        currentCharges = maxCharges;

        if (flashlight != null)
            flashlight.enabled = false;
        
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
        if (currentCharges <= 0)
        {
            Debug.Log("Sin batería");
            return;
        }

        currentCharges--;

        StartCoroutine(FlashRoutine());

        Ray ray = new Ray(
            flashlight.transform.position,
            flashlight.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            GhostEnemy ghost = hit.collider.GetComponent<GhostEnemy>();

            if (ghost != null)
            {
                ghost.Die();
            }
        }
        
        currentCharges--;
        UpdateUI();
    }

    private System.Collections.IEnumerator FlashRoutine()
    {
        flashlight.enabled = true;

        yield return new WaitForSeconds(1f);

        flashlight.enabled = false;
    }

    public void AddCharge(int amount)
    {
        currentCharges = Mathf.Min(
            currentCharges + amount,
            maxCharges
        );
        
        UpdateUI();
    }

    public int GetCharges()
    {
        return currentCharges;
    }
    
    private void UpdateUI()
    {
        batteryText.text = "" + currentCharges;
    }
}
