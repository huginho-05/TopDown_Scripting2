using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float floatHeight = 0.25f;
    public float floatSpeed = 2f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Rotación sobre si mismo
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Movimiento vertical
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
