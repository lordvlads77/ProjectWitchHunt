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
    [SerializeField] private GameObject _startMenu = default;
    private readonly string _pauseDebugMsg = "Paused";
    [SerializeField] private GameObject _uiInGamePanel = default;
    [SerializeField] private GameObject _uiPausePanel = default;
    [SerializeField] private GameObject _uiGameOverPanel = default;
    [FormerlySerializedAs("_uiStorePanel")] [SerializeField] private GameObject _uiStore = default;
    [SerializeField] private GameObject _uiItemStorePanel = default;
    private readonly String _itemBoughtDebugMsg = "Item Bought";
    [Header("Health Bar ui")]
    [SerializeField] private ProgressLifeBars HealthBar = default;
    [SerializeField] GameObject _joystick = default;
    [FormerlySerializedAs("isSplashScreenActive")] [SerializeField] private bool isUIActive = default;


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
        isUIActive = true;
    }
    
    void Update()
    {
        if (isUIActive == true)
        {
            _joystick.SetActive(false);
        }
        else
        {
            _joystick.SetActive(true);
        }
    }
    
    // public void InitGame()
    // {
    //     _SplashPanel.SetActive(false);
    //     _startMenuPanel.SetActive(true);
    // }
    
    public void PlayButton()
    {
        Time.timeScale = 1;
        _startMenuPanel.SetActive(false);
        _uiInGamePanel.SetActive(true);
        isUIActive = false;
        
    }

    public void Pause()
    {
        Debug.Log(_pauseDebugMsg);
        _uiPausePanel.SetActive(true);
        _uiInGamePanel.SetActive(false);
        isUIActive = true;
        Time.timeScale = 0;
    }

    public void SwitchAtk()
    {
        PowerToggle.Instance.ToggleButtonImage();
    }
    
    public void UnPause()
    {
        _uiPausePanel.SetActive(false);
        _uiInGamePanel.SetActive(true);
        Time.timeScale = 1;
        isUIActive = false;
    }
    
    public void MainMenu()
    {
        _uiPausePanel.SetActive(false);
        _startMenu.SetActive(true);
        isUIActive = true;
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
