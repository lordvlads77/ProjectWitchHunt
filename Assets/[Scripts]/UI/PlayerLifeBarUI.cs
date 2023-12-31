using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBarUI : MonoBehaviour
{
    public static PlayerLifeBarUI Instance { get; private set; }
    [SerializeField] private float _drainTime = 0.25f;
    [SerializeField] private Gradient _healthBarGradient = default;
    public Image _image;
    [SerializeField] private float _target = default;
    private Color _newHealthBarColor;
    private Coroutine drainHealthBarCoroutine;
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth = 100f;

    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (_image == null)
            _image = GetComponent<Image>();
        _image.color = _healthBarGradient.Evaluate(_target);
        HealthGradientUpdate();
        currentHealth = maxHealth;
    }

    public void UpdateHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0f, maxHealth);
        UpdateHealthBar(maxHealth, currentHealth);
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
        drainHealthBarCoroutine = StartCoroutine(DrainHealthBar());
        HealthGradientUpdate();
    }

    private IEnumerator DrainHealthBar()
    {
        float fillAmount = _image.fillAmount;
        Color currentColor = _image.color;
        
        float elapsedTime = 0f;
        while (elapsedTime < _drainTime)
        {
            elapsedTime += Time.deltaTime;
            // lerp the fill amount
            _image.fillAmount = Mathf.Lerp(fillAmount, _target, (elapsedTime / _drainTime));
            // lerp the color based on the gradient
            _image.color = Color.Lerp(currentColor, _newHealthBarColor, (elapsedTime / _drainTime));
            
            yield return null;
        }
    }

    private void HealthGradientUpdate()
    { 
        _newHealthBarColor = _healthBarGradient.Evaluate(_target);
    }
}
