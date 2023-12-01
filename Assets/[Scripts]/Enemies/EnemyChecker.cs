using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName ="New Checker Enemy", menuName ="Enemiess/CheckerEnemy")]
public class EnemyChecker : ScriptableObject
{
    public string enemyName;
    public bool isDead = false;
}
