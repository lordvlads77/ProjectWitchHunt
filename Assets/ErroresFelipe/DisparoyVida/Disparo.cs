using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    public float damagePorDisparo = 10f;
    public float rango = 100f;
    public string tagEnemigo = "Enemigo";
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform puntoDisparo; // Punto de origen del proyectil
    public float velocidadProyectil = 10f;

    private bool puedeDisparar = true;

    void Update()
    {
        if (puedeDisparar)
        {
            DetectarEnemigoYDisparar();
        }
    }

    void DetectarEnemigoYDisparar()
    {
        RaycastHit hit;

        if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit, rango))
        {
            if (hit.collider.CompareTag(tagEnemigo))
            {
                Debug.Log("Enemigo detectado en rango. Disparando...");
                Disparar(hit.collider.gameObject);
            }
        }
    }

    void Disparar(GameObject enemigo)
    {
        Debug.Log("Disparando...");

        // Desactiva la capacidad de disparar para evitar m�ltiples disparos en el mismo ciclo
        puedeDisparar = false;

        // Instancia un proyectil y configura su direcci�n y velocidad
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody proyectilRigidbody = proyectil.GetComponent<Rigidbody>();
        proyectilRigidbody.velocity = transform.forward * velocidadProyectil;

        // Aplica da�o al enemigo
        Enemigo scriptEnemigo = enemigo.GetComponent<Enemigo>();
        if (scriptEnemigo != null)
        {
            scriptEnemigo.RecibirDanio(damagePorDisparo);
        }

        // Puedes configurar otras propiedades del proyectil aqu�, por ejemplo, su da�o, efectos, etc.

        // Espera un tiempo antes de poder disparar nuevamente
        StartCoroutine(ReactivarDisparo());
    }

    IEnumerator ReactivarDisparo()
    {
        // Espera 0.5 segundos antes de reactivar la capacidad de disparar
        yield return new WaitForSeconds(0.5f);
        puedeDisparar = true;
    }
}