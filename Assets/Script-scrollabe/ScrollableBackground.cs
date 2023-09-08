using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableBackground : MonoBehaviour
{
    [System.Serializable]
    public class WeightedBackground
    {
        public GameObject background;
        public float weight;
    }

    public List<WeightedBackground> weightedBackgrounds; // Lista de fondos ponderados
    public float scrollSpeed = 1.0f;

    private GameObject currentBackground;

    void Start()
    {
        // Inicialmente, elige un fondo aleatorio basado en pesos
        currentBackground = ChooseRandomBackground();
        currentBackground.SetActive(true);
    }

    void Update()
    {
        // Desplaza el fondo actual
        Vector3 currentPosition = currentBackground.transform.position;
        float newPositionX = currentPosition.x - (scrollSpeed * Time.deltaTime);
        currentBackground.transform.position = new Vector3(newPositionX, currentPosition.y, currentPosition.z);
    }

    GameObject ChooseRandomBackground()
    {
        // Calcula el peso total de todos los fondos
        float totalWeight = 0f;
        foreach (var weightedBackground in weightedBackgrounds)
        {
            totalWeight += weightedBackground.weight;
        }

        // Elige un número aleatorio entre 0 y el peso total
        float randomValue = Random.Range(0f, totalWeight);

        // Encuentra el fondo correspondiente al valor aleatorio
        foreach (var weightedBackground in weightedBackgrounds)
        {
            if (randomValue < weightedBackground.weight)
            {
                return weightedBackground.background;
            }
            randomValue -= weightedBackground.weight;
        }

        // Por si acaso, devuelve el último fondo en caso de problemas
        return weightedBackgrounds[weightedBackgrounds.Count - 1].background;
    }
}