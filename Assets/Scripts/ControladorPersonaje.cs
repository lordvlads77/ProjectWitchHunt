using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControladorPersonaje : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image joystickBase;
    public Image joystickDeslizante;
    public float velocidadMovimiento = 5.0f;

    private Vector3 direccionMovimiento = Vector3.zero;
    private bool joystickTocado = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        joystickTocado = true;

        RectTransform rectTransform = joystickBase.GetComponent<RectTransform>();
        rectTransform.position = eventData.position;
        joystickDeslizante.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (joystickTocado)
        {
            Vector3 posicionDeslizante = joystickDeslizante.transform.position;
            Vector3 posicionBase = joystickBase.transform.position;
            direccionMovimiento = (posicionDeslizante - posicionBase).normalized;
            transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTocado = false;
        direccionMovimiento = Vector3.zero;
        joystickDeslizante.transform.position = joystickBase.transform.position;
    }
}