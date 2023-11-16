using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance { get; private set; }
    private readonly int _playerDeath = Animator.StringToHash("isDead");
    private readonly int _playerAttacking = Animator.StringToHash("isPattack");
    private readonly int _EnemyPigAttack = Animator.StringToHash("attackk");
    private readonly int _EnemyPigDeath = Animator.StringToHash("dead");
    private readonly int _EnemyFoxAttack = Animator.StringToHash("attack");
    private readonly int _EnemyFoxDeath = Animator.StringToHash("moricion");
    private readonly int _EnemyTurkeyAttack = Animator.StringToHash("turkeyisAtk");
    private readonly int _EnemyTurkeyDeath = Animator.StringToHash("peto");
    private readonly int _fadeIn = Animator.StringToHash("FadeIn");
    private readonly int _fadeOut = Animator.StringToHash("FadeOut");

    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayerDeath(Animator animator)
    {
        animator.SetBool(_playerDeath, true);
    }
    
    public void PlayerAttacking(Animator animator)
    {
        animator.SetTrigger(_playerAttacking);
    }
    
    public void EnemyPigAttack(Animator animator)
    {
        animator.SetTrigger(_EnemyPigAttack);
    }
    
    public void EnemyPigDeath(Animator animator)
    {
        animator.SetTrigger(_EnemyPigDeath);
    }
    
    public void EnemyFoxAttack(Animator animator)
    {
        animator.SetTrigger(_EnemyFoxAttack);
    }
    
    public void EnemyFoxDeath(Animator animator)
    {
        animator.SetTrigger(_EnemyFoxDeath);
    }
    
    public void EnemyTurkeyAttack(Animator animator)
    {
        animator.SetTrigger(_EnemyTurkeyAttack);
    }
    
    public void EnemyTurkeyDeath(Animator animator)
    {
        animator.SetTrigger(_EnemyTurkeyDeath);
    }
    
    public void StopPlayerAttacking(Animator animator)
    {
        animator.SetBool(_playerAttacking, false);
    }

    public void FadeInAnim(Animator animator)
    {
        animator.Play(_fadeIn);
    }

    public void FadeOutAnim(Animator animator)
    {
        animator.Play(_fadeOut);
    }
}
