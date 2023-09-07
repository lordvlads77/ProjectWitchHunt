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
        // Cuando se toca la pantalla, habilita el joystick.
        joystickTocado = true;

        // Mueve el joystick a la posici�n del toque.
        RectTransform rectTransform = joystickBase.GetComponent<RectTransform>();
        rectTransform.position = eventData.position;
        joystickDeslizante.transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (joystickTocado)
        {
            // Calcula la direcci�n del joystick virtual.
            Vector3 posicionDeslizante = joystickDeslizante.transform.position;
            Vector3 posicionBase = joystickBase.transform.position;
            direccionMovimiento = (posicionDeslizante - posicionBase).normalized;

            // Mueve el personaje en funci�n de la direcci�n.
            transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Cuando se levanta el dedo, deshabilita el joystick y reinicia la direcci�n.
        joystickTocado = false;
        direccionMovimiento = Vector3.zero;

        // Coloca el joystick de nuevo en su posici�n inicial.
        joystickDeslizante.transform.position = joystickBase.transform.position;
    }
}