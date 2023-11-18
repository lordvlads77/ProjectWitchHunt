using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    [SerializeField]
    public float damagePorDisparo = 10f;
    [SerializeField]
    public string tagEnemigo = "Enemigo";
    [SerializeField]
    public GameObject proyectilPrefab; // Prefab del proyectil
    [SerializeField]
    public Transform puntoDisparo; // Punto de origen del proyectil
    [SerializeField]
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
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Disparando...");
            Disparar();
        }
    }

    void Disparar()
    {
        // Instancia un proyectil y configura su dirección y velocidad
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody proyectilRigidbody = proyectil.GetComponent<Rigidbody>();
        proyectilRigidbody.velocity = transform.forward * velocidadProyectil;

        // Configura el script del proyectil para saber a qué enemigo pertenece
        /*Proyectil scriptProyectil = proyectil.GetComponent<Proyectil>();
        if (scriptProyectil != null)
        {
            scriptProyectil.SetTagEnemigo(tagEnemigo);
            scriptProyectil.SetDamagePorDisparo(damagePorDisparo);
        }*/

        // Desactiva la capacidad de disparar para evitar múltiples disparos en el mismo ciclo
        puedeDisparar = false;

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