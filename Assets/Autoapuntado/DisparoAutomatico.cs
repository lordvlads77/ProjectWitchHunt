using UnityEngine;

public class DisparoAutomatico : MonoBehaviour
{
    public Transform puntoDisparo;
    public GameObject proyectil;
    public float velocidadDisparo = 5f;
    public float frecuenciaDisparo = 1.5f;
    public LayerMask capaEnemigo;

    private void Update()
    {
        if (DetectarEnemigo())
        {
            Disparar();
        }
    }

    bool DetectarEnemigo()
    {
        RaycastHit hit;
        if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit, Mathf.Infinity, capaEnemigo))
        {
            return true; // Hay un enemigo en la línea de visión
        }
        return false;
    }

    void Disparar()
    {
        GameObject bala = Instantiate(proyectil, puntoDisparo.position, Quaternion.identity);
        bala.GetComponent<Rigidbody>().velocity = puntoDisparo.forward * velocidadDisparo;
    }
}