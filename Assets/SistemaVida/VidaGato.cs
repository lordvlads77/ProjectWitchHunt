using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaGato : MonoBehaviour
{
    public static VidaGato Instance { get; private set; }
    public float vida = 100;
    public Image barraDevida;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _destroyPlayer;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _floatingJoystick;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] private bool isPetado = true;

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
        
    }
    
    void Update()
    {
        

        if (isPetado == false)
        {
            StopCoroutine(DeathAnim());
        }

        if (vida <= 0 && isPetado == true)
        {
            StartCoroutine(DeathAnim());
            isPetado = false;
        }
    }

    public IEnumerator DeathAnim()
    {
        Destroy(_enemy);
        Destroy(_enemy2);
        Destroy(_enemy3);
        AnimationController.Instance.PlayerDeath(_animator);
        _floatingJoystick.SetActive(false);
        yield return new WaitForSeconds(1f);
        ParticleController.Instance.SpwnDeathParticle();
        AudioController.Instance.PlayDeathSFX();
        yield return new WaitForSeconds(2f);
        Destroy(_destroyPlayer);
    }
    
    public void UpdateHealth(float newHealth)
    {
        vida = Mathf.Clamp(newHealth, 0f, maxHealth);
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        PlayerLifeBarUI.Instance.UpdateHealthBar(maxHealth, vida);
    }

    public void DañoPlayer(int dmgAmount)
    {
        vida += dmgAmount;
        if (vida <= 0)
        {
            vida = 0;
        }
        vida = Mathf.Clamp(vida, 0, 100);

        //barraDevida.fillAmount = vida / 100;
        PlayerLifeBarUI.Instance.UpdateHealthBar(100, vida);
        AudioController.Instance.PlayEnemyAttackSFX();
    }
    
}