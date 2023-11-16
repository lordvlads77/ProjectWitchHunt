using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaGato : MonoBehaviour
{
    public float vida = 100;
    public Image barraDevida;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _destroyPlayer;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _floatingJoystick;
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth = 100f;
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        //barraDevida.fillAmount = vida / 100;
        PlayerLifeBarUI.Instance.UpdateHealthBar(100, vida);

        if (vida <= 0)
        {
            StartCoroutine(DeathAnim());
        }
    }

    private IEnumerator DeathAnim()
    {
        Destroy(_enemy);
        Destroy(_enemy2);
        Destroy(_enemy3);
        AnimationController.Instance.PlayerDeath(_animator);
        _floatingJoystick.SetActive(false);
        yield return new WaitForSeconds(2f);
        Destroy(_destroyPlayer);
        UIController.Instance.Moricion();
    }

}