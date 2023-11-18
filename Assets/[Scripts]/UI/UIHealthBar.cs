using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private float _drainTime = 0.25f;
    [SerializeField] private Gradient _healthBarGradient = default;
    private Image _image;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _target = default;
    private Color _newHealthBarColor;
    private Coroutine drainHealthBarCoroutine;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.color = _healthBarGradient.Evaluate(_target);
        HealthGradientUpdate();
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _target = currentHealth / maxHealth;
        StartCoroutine(DrainHealthBar());
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
