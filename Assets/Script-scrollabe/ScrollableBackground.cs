using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableBackground : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    void Update()
    {
        // Obtén la posición actual del fondo
        Vector3 currentPosition = transform.position;

        // Calcula la nueva posición desplazada
        float newPositionX = currentPosition.x - (scrollSpeed * Time.deltaTime);

        // Aplica la nueva posición al fondo
        transform.position = new Vector3(newPositionX, currentPosition.y, currentPosition.z);
    }
}