using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic; // Referencia al AudioSource de la música de fondo
    public AudioSource soundEffectSource; // Referencia al AudioSource de los efectos de sonido

    // Método para reproducir efectos de sonido
    public void PlaySound(AudioClip sound)
    {
        soundEffectSource.PlayOneShot(sound);
    }

    // Método para reproducir música de fondo
    public void PlayBackgroundMusic(AudioClip music)
    {
        backgroundMusic.clip = music;
        backgroundMusic.loop = true; // Reproducir en bucle
        backgroundMusic.Play();
    }
}