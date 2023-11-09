using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerToggle : MonoBehaviour
{
    public static PowerToggle Instance { get; private set; }
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite originalSprite;
    [SerializeField] private Sprite clickedSprite; 

    private bool isToggled = false;

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
        // Get the Image component attached to the Button
        buttonImage = GetComponent<Image>();

        // Store the original sprite
        originalSprite = buttonImage.sprite;
    }

    public void ToggleButtonImage()
    {
        // Toggle the state of the button
        isToggled = !isToggled;

        // Change the button's image based on the toggle
        if (isToggled)
        {
            buttonImage.sprite = clickedSprite;
            ParticleController.Instance.SpwnProyectileBlueParticle();
        }
        else
        {
            buttonImage.sprite = originalSprite;
            ParticleController.Instance.SpwnProyectilePinkParticle();
        }
    }
}
