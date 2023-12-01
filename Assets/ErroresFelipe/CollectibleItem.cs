using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Enemy Checker", menuName = "Enemies/EnemyChecker")]
public class CollectibleItem : ScriptableObject
{
    public string itemName;
    [FormerlySerializedAs("isCollected")] public bool IsCollected = false;
}
