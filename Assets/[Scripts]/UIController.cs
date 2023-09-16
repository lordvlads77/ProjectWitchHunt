using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private float time,second = default;
    [SerializeField] public Image _imgFiller = default;
    void Start()
    {
        second = 5f;
        Invoke("LoadGame", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            _imgFiller.fillAmount = time / second;
        }
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(4);
    }
}
