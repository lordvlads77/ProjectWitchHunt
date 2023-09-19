using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    private float time,second = default;
    [SerializeField] private Image _imgFiller = default;
    [FormerlySerializedAs("_panel")] [SerializeField] private GameObject _SplashPanel = default;
    [SerializeField] private GameObject _startMenuPanel = default;
    private string _pauseDebugMsg = "Paused";
    [SerializeField] private GameObject _uiInGamePanel = default;


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
        Invoke("InitGame", 5f);
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
    }

    public void SwitchAtk()
    {
        PowerToggle.Instance.ToggleButtonImage();
        //TODO: Descubrir porque tengo que hacer click 2 veces para mandarlo a llamar.
    }
}
