using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Animator fadeAnimator;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneWithFade(sceneName));
    }

    private IEnumerator ChangeSceneWithFade(string sceneName)
    {
        // Trigger "fade in" animation
        fadeAnimator.Play("FadeIn");

        // Espera un tiempo para que termine la animación de "fade in"
        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Cambia a la nueva escena
        SceneManager.LoadScene("Level2");

        // Trigger "fade out" animation
        fadeAnimator.Play("FadeOut");
    }
}