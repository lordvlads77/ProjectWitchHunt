using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableBackground : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    void Update()
    {
        // Obt�n la posici�n actual del fondo
        Vector3 currentPosition = transform.position;

        // Calcula la nueva posici�n desplazada
        float newPositionX = currentPosition.x - (scrollSpeed * Time.deltaTime);

        // Aplica la nueva posici�n al fondo
        transform.position = new Vector3(newPositionX, currentPosition.y, currentPosition.z);
    }
}