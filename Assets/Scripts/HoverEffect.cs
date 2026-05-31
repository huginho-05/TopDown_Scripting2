using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Texto")]
    public TextMeshProUGUI texto;

    [Header("Efecto hover")]
    public Color colorHover;
    public Vector3 escalaHover = new Vector3(1.2f, 1.2f, 1f);

    private Color colorOriginal;
    private Vector3 escalaOriginal;

    void Start()
    {
        if (texto != null)
        {
            colorOriginal = texto.color;
            escalaOriginal = texto.transform.localScale;
        }
    }

    // Pasar raton por encima
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (texto == null) return;

        texto.color = colorHover;
        texto.transform.localScale = escalaHover;
    }

    // Dejar de pasar raton por encima
    public void OnPointerExit(PointerEventData eventData)
    {
        if (texto == null) return;

        texto.color = colorOriginal;
        texto.transform.localScale = escalaOriginal;
    }
}
