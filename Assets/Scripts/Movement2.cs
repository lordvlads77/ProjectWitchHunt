using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;

    private Vector2 inicioToque;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch primerToque = Input.GetTouch(0);

            switch (primerToque.phase)
            {
                case TouchPhase.Began:
                    inicioToque = primerToque.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 desplazamiento = primerToque.position - inicioToque;

                    Vector3 direccionMovimiento = new Vector3(desplazamiento.x, 0, desplazamiento.y);

                    transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);

                    inicioToque = primerToque.position;
                    break;
            }
        }
    }
}