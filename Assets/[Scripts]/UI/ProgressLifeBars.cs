using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressLifeBars : MonoBehaviour
{
    [SerializeField] private Image _progressLifeBar;
    [SerializeField] private float _progressLifeBarSpeed = 1f;
    [SerializeField] private UnityEvent<float> OnProgress;
    [SerializeField] private UnityEvent OnProgressComplete;
    [Header("Couritine")]
    private Coroutine _animCoroutine;
    [SerializeField] private Gradient colorGradient = default;

    private void Start()
    {
        if (_progressLifeBar.type != Image.Type.Filled)
        {
            Debug.LogError($"{name}'s Image must be of type Filled, please change it$");
        }
    }

    public void SetProgress(float progress)
    {
        SetProgress(progress, _progressLifeBarSpeed);
    }

    public void SetProgress(float progress, float speed)
    {
        if (progress < 0 || progress > 1)
        {
            Debug.LogError($"{name}'s progress must be between 0 and 1. Got {progress}. Clamping");
            progress = Mathf.Clamp01(progress);
        }
        if (progress != _progressLifeBar.fillAmount)
        {
            if (_animCoroutine != null)
            {
                StopCoroutine(_animCoroutine);
            }
            _animCoroutine = StartCoroutine(AnimateProgress(progress, speed));
        }
    }

    private IEnumerator AnimateProgress(float progress, float speed)
    {
        float _time = 0;
        float _initialProgress = _progressLifeBar.fillAmount;

        while (_time < 1)
        {
            _progressLifeBar.fillAmount = Mathf.Lerp(_initialProgress, progress, _time);
            _time += Time.deltaTime * speed;
            _progressLifeBar.color = colorGradient.Evaluate(0 - _progressLifeBar.fillAmount);
            OnProgress?.Invoke(_progressLifeBar.fillAmount);
            yield return null;
        }
        _progressLifeBar.fillAmount = progress;
        _progressLifeBar.color = colorGradient.Evaluate(0 - _progressLifeBar.fillAmount);
        OnProgress?.Invoke(progress);
        OnProgressComplete?.Invoke();
    }
}
