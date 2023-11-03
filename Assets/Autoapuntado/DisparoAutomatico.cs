using UnityEngine;

public class DisparoAutomatico : MonoBehaviour
{
    public Transform puntoDisparo;
    public GameObject proyectil;
    public float velocidadDisparo = 15f;
    public float frecuenciaDisparoCercano = 1.5f;
    public float frecuenciaDisparoLejano = 0.5f;
    public float distanciaCercana = 5f;
    public float distanciaLejana = 15f;
    public string tagEnemigo = "Enemigo";
    public GameObject impactoParticulas; // Agrega tu efecto de partículas desde el Inspector

    private GameObject bala;

    private void Update()
    {
        float distanciaEnemigo = EncontrarEnemigoMasCercano();

        if (distanciaEnemigo <= distanciaCercana)
        {
            Disparar(frecuenciaDisparoCercano);
        }
        else if (distanciaEnemigo > distanciaLejana)
        {
            CancelInvoke("HacerDisparo");
        }
        else if (distanciaEnemigo > distanciaCercana && distanciaEnemigo <= distanciaLejana)
        {
            Disparar(frecuenciaDisparoLejano);
        }
    }

    float EncontrarEnemigoMasCercano()
    {
        float distancia = Mathf.Infinity;
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);
        foreach (GameObject enemigo in enemigos)
        {
            float distanciaActual = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distanciaActual < distancia)
            {
                distancia = distanciaActual;
            }
        }
        return distancia;
    }

    void Disparar(float frecuenciaDisparo)
    {
        if (!IsInvoking("HacerDisparo"))
        {
            InvokeRepeating("HacerDisparo", 0f, frecuenciaDisparo);
        }
    }

    void HacerDisparo()
    {
        GameObject enemigoCercano = EncontrarEnemigoMasCercanoObject(); // Encuentra el GameObject del enemigo más cercano
        if (enemigoCercano != null)
        {
            if (bala != null) Destroy(bala); // Destruye la bala anterior si existe una
            bala = Instantiate(proyectil, puntoDisparo.position, Quaternion.identity);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            Vector3 direccion = (enemigoCercano.transform.position - puntoDisparo.position).normalized;
            rb.velocity = direccion * velocidadDisparo;
            Destroy(bala, 3.0f);
        }
    }

    GameObject EncontrarEnemigoMasCercanoObject()
    {
        float distancia = Mathf.Infinity;
        GameObject enemigoCercano = null;
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);
        foreach (GameObject enemigo in enemigos)
        {
            float distanciaActual = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distanciaActual < distancia)
            {
                distancia = distanciaActual;
                enemigoCercano = enemigo;
            }
        }
        return enemigoCercano;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemigo) && bala != null)
        {
            Destroy(bala); // Destruye la bala al colisionar con el enemigo
            MostrarParticulasImpacto(other.transform.position); // Muestra partículas al impactar con el enemigo
        }
    }

    void MostrarParticulasImpacto(Vector3 position)
    {
        GameObject impacto = Instantiate(impactoParticulas, position, Quaternion.identity);
        Destroy(impacto, 2.0f);
    }
}