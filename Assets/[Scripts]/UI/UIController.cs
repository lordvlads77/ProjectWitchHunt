using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    private float time,second = default;
    [SerializeField] private Image _imgFiller = default;
    [FormerlySerializedAs("_panel")] [SerializeField] private GameObject _SplashPanel = default;
    [SerializeField] private GameObject _startMenuPanel = default;
    private readonly string _pauseDebugMsg = "Paused";
    [SerializeField] private GameObject _uiInGamePanel = default;
    [SerializeField] private GameObject _uiPausePanel = default;
    [SerializeField] private GameObject _uiGameOverPanel = default;
    [FormerlySerializedAs("_uiStorePanel")] [SerializeField] private GameObject _uiStore = default;
    [SerializeField] private GameObject _uiItemStorePanel = default;
    private readonly String _itemBoughtDebugMsg = "Item Bought";
    [Header("Health Bar ui")]
    [SerializeField] private ProgressLifeBars HealthBar = default;


    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        second = 5f;
        Invoke(nameof(InitGame), 5f);
    }
    
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            _imgFiller.fillAmount = time / second;
        }
    }
    
    public void InitGame()
    {
        _SplashPanel.SetActive(false);
        _startMenuPanel.SetActive(true);
    }
    
    public void PlayButton()
    {
        _startMenuPanel.SetActive(false);
        _uiInGamePanel.SetActive(true);
    }

    public void Pause()
    {
        Debug.Log(_pauseDebugMsg);
        _uiPausePanel.SetActive(true);
        _uiInGamePanel.SetActive(false);
    }

    public void SwitchAtk()
    {
        PowerToggle.Instance.ToggleButtonImage();
    }
    
    public void UnPause()
    {
        _uiPausePanel.SetActive(false);
        _uiInGamePanel.SetActive(true);
    }
    
    public void MainMenu()
    {
        _uiPausePanel.SetActive(false);
        _startMenuPanel.SetActive(true);
    }

    public void Respawn()
    {
        SceneManager.LoadScene(6);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); For use in the future in another context
        _uiGameOverPanel.SetActive(false);
        _SplashPanel.SetActive(false);
        _startMenuPanel.SetActive(false);
    }
    
    public void BackToStoreUI()
    {
        _uiItemStorePanel.SetActive(false);
        _uiStore.SetActive(true);
    }

    public void ItemBought()
    {
        Debug.Log(_itemBoughtDebugMsg);
    }
}
