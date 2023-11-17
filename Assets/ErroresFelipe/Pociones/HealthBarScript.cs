using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private Image healthBarImage;
    [SerializeField]
    public float maxHealth = 100f;
    [SerializeField]
    public float currentHealth;

    private void Start()
    {
        //healthBarImage = GetComponent<Image>();

        if (healthBarImage == null)
        {
            Debug.LogError("Image component not found on the same GameObject as HealthBarScript.");
        }

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0f, maxHealth);
        PlayerLifeBarUI.Instance.UpdateHealthBar(100, currentHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            // float fillAmount = currentHealth / maxHealth;
            // healthBarImage.fillAmount = fillAmount;
            PlayerLifeBarUI.Instance.UpdateHealthBar(maxHealth, currentHealth);
        }
        else
        {
            Debug.LogError("Image component is null in HealthBarScript.");
        }
    }
}