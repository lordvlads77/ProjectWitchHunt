using System;
using System.Collections;
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
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;


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
        // Time.timeScale = 1;
        _startMenuPanel.SetActive(false);
        _uiInGamePanel.SetActive(true); 
        isUIActive = false;
        _enemy.SetActive(true);
        _enemy2.SetActive(true);
        _enemy3.SetActive(true);
        
    }

    public void Pause()
    {
        Debug.Log(_pauseDebugMsg);
        _uiPausePanel.SetActive(true);
        _uiInGamePanel.SetActive(false);
        isUIActive = true;
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Paused : GameState.Gameplay;
        GameStateManager.Instance.SetState(newGameState);
    }

    public void SwitchAtk()
    {
        PowerToggle.Instance.ToggleButtonImage();
    }
    
    public void UnPause()
    {
        _uiPausePanel.SetActive(false);
        _uiInGamePanel.SetActive(true);
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Paused ? GameState.Gameplay : GameState.Paused;
        GameStateManager.Instance.SetState(newGameState);
        isUIActive = false;
    }
    
    public void MainMenu()
    {
        StartCoroutine(MainMenuStuff());
        // isUIActive = true;
    }
    
    public void Respawn()
    {
        SceneManager.LoadScene(0);
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

    public void Ataque()
    {
        DisparoAutomatico.Instance.Disparar(3f);
    }

    public void Moricion()
    {
        _uiInGamePanel.SetActive(false);
        _uiGameOverPanel.SetActive(true);
        isUIActive = true;
    }

    private IEnumerator MainMenuStuff()
    {
        _uiPausePanel.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
    }
}
