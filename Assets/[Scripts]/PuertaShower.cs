using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaShower : MonoBehaviour
{
    public List<EnemyChecker> deadenemies = new List<EnemyChecker>();
    [SerializeField] GameObject _puerta;
    // Start is called before the first frame update

    private void Update()
    {
        if (CheckRequiredEnemies())
        {
            Debug.Log("Dead Enemis");
            _puerta.SetActive(true);
        }
        else
        {
            _puerta.SetActive(false);
        }
    }

    private bool CheckRequiredEnemies()
    {
        foreach (EnemyChecker deadenemy in deadenemies)
        {
            if (!deadenemy.isDead)
            {
                return false; // if the enemies are not dead
            }
        }
        return true; //if all the enemies are petados.
    }
}
