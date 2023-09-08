using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tienda : MonoBehaviour
{
    [SerializeField] List<PlantillaInformacionItem> informacionItems;
    [SerializeField] GameObject plantillaObjetoTienda;
    [SerializeField] TextMeshProUGUI textoMonedasTotales;

    public void AbrirTienda()
    {
        gameObject.SetActive(true);

        var plantillaItem = plantillaObjetoTienda.GetComponent<PlantillaItemTienda>();

        foreach (var item in informacionItems)
        {
            plantillaItem.imagen.sprite = item.image;
            plantillaItem.titulo.text = item.titulo;
            plantillaItem.textoPrecio.text = item.precio.ToString();

            Instantiate(plantillaItem, transform);
        }
    }

    public void CerrarTienda()
    {
        gameObject.SetActive(false);
    }
}