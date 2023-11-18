using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    private int coins = 0;
    public TMP_Text UiAmount;

    private void Awake()
    {
        instance = this;
    }

    public static CoinManager GetCoinManager()
    {
        return instance;
    }

    public void AddCoin()
    {
        coins++;
        UiAmount.text = coins.ToString();

    }
}
