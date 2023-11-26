using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    public static Fading Instance { get; private set; }
    [SerializeField] private Animator _animatorTransition;
    
    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void TransFade()
    {
        StartCoroutine(Fadiing());
    }
    
    IEnumerator Fadiing()
    {
        AnimationController.Instance.theFade(_animatorTransition);
        yield return new WaitForSeconds(1f);
    }
}
