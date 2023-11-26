using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    public AudioClip soundEffectClip; // Asigna el efecto de sonido desde el Inspector de Unity
    public AudioClip backgroundMusicClip; // Asigna la m�sica de fondo desde el Inspector de Unity

    public SoundManager soundManager; // Referencia al SoundManager

    void Start()
    {
        // Reproducir la m�sica de fondo al iniciar el juego
        soundManager.PlayBackgroundMusic(backgroundMusicClip);
    }

    void Update()
    {
        // Ejemplo de reproducci�n de efectos de sonido al presionar una tecla (puedes adaptarlo a tus necesidades)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundManager.PlaySound(soundEffectClip);
        }
    }
}