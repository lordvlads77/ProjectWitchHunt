using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic; // Referencia al AudioSource de la m�sica de fondo
    public AudioSource soundEffectSource; // Referencia al AudioSource de los efectos de sonido

    // M�todo para reproducir efectos de sonido
    public void PlaySound(AudioClip sound)
    {
        soundEffectSource.PlayOneShot(sound);
    }

    // M�todo para reproducir m�sica de fondo
    public void PlayBackgroundMusic(AudioClip music)
    {
        backgroundMusic.clip = music;
        backgroundMusic.loop = true; // Reproducir en bucle
        backgroundMusic.Play();
    }
}