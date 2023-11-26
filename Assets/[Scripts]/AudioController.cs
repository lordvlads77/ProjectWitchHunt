using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [Header("Music Audio Source")]
    [FormerlySerializedAs("_audioSource")] [SerializeField] private AudioSource[] _musicAudioSource = default;
    [Header("SFX Audio Source")]
    [SerializeField] private AudioSource _sfxAudioSource = default;
    [Header("Potions")]
    [SerializeField] private AudioClip _potionUseSFX = default;
    [SerializeField] private AudioClip _potionEndedSFX = default;
    [SerializeField] private AudioClip _healingSFX = default;
    [Header("Enemy")]
    [SerializeField] private AudioClip _enemyAttackSFX = default;
    [FormerlySerializedAs("_enemyDeathSFX")] [SerializeField] private AudioClip _DeathSFX = default;
    [Header("Player")]
    [SerializeField] private AudioClip _playerAttackSFX = default;
    [SerializeField] private AudioClip _playerDamageSFX = default;
    [Header("UI")]
    [SerializeField] private AudioSource _UIAudioSource = default;

    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayMenuMusic()
    {
        _musicAudioSource[0].Play();
    }
    
    public void PauseMenuMusic()
    {
        _musicAudioSource[0].Pause();
    }
    
    public void PlayGamePlayMusic()
    {
        _musicAudioSource[1].Play();
    }
    
    public void PauseGamePlayMusic()
    {
        _musicAudioSource[1].Pause();
    }
    
    public void PlayPauseMusic()
    {
        _musicAudioSource[2].Play();
    }
    
    public void PausePauseMusic()
    {
        _musicAudioSource[2].Pause();
    }
    
    public void PlayStoreMusic()
    {
        _musicAudioSource[3].Play();
    }
    
    public void PauseStoreMusic()
    {
        _musicAudioSource[3].Pause();
    }
    
    public void PlayGameOverMusic()
    {
        _musicAudioSource[4].Play();
    }
    
    public void PauseGameOverMusic()
    {
        _musicAudioSource[4].Pause();
    }
    
    public void PlayPotionUseSFX()
    {
        _sfxAudioSource.PlayOneShot(_potionUseSFX, 1f);
    }
    
    public void PlayPotionEndedSFX()
    {
        _sfxAudioSource.PlayOneShot(_potionEndedSFX, 1f);
    }
    
    public void PlayHealingSFX()
    {
        _sfxAudioSource.PlayOneShot(_healingSFX, 1f);
    }
    
    public void PlayEnemyAttackSFX()
    {
        _sfxAudioSource.PlayOneShot(_enemyAttackSFX, 1f);
    }
    
    public void PlayDeathSFX()
    {
        _sfxAudioSource.PlayOneShot(_DeathSFX, 2f);
    }
    
    public void PlayPlayerAttackSFX()
    {
        _sfxAudioSource.PlayOneShot(_playerAttackSFX, 1f);
    }
    
    public void PlayPlayerDamageSFX()
    {
        _sfxAudioSource.PlayOneShot(_playerDamageSFX, 1f);
    }
    
    public void PlayButtonClickSFX()
    {
        _UIAudioSource.Play();
    }
    
    
    
    
}
