using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MenuTienda", menuName ="Plantilla/InfoItemTienda")]
public class PlantillaInformacionItem : ScriptableObject
{
    [SerializeField]
    public string titulo;
    [SerializeField]
    public Sprite image;
    [SerializeField]
    public int precio;
}
