using UnityEngine;

public class ColorObjects : MonoBehaviour
{
    public KeySO key;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();

        renderer.GetPropertyBlock(block);

        block.SetColor("_BaseColor", key.color);

        renderer.SetPropertyBlock(block);
    }
}
