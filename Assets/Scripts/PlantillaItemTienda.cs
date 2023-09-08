using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantillaItemTienda : MonoBehaviour
{
    [SerializeField]
    public Image imagen;
    [SerializeField]
    public TextMeshProUGUI textoPrecio;
    [SerializeField]
    public TextMeshProUGUI titulo;
    [SerializeField]
    public Button bottonComprar;
    int precio;
    int monedaTotales;
    void Start()
    {
        precio = int.Parse(textoPrecio.text);
    }

    void Update()
    {
        monedaTotales = PlayerPrefs.GetInt("monedasTotales");
        if(precio > monedaTotales)
        {
            bottonComprar.interactable = false;
        }
    }

    public void Comprar()
    {
        monedaTotales -= precio;
        PlayerPrefs.SetInt("monedasTotales", monedaTotales);
    }
}
