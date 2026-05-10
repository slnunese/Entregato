using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // Acceso global (Singleton)

    [Header("🎵 Sonidos del jugador")]
    public AudioClip sonidoCaminar;
    public AudioClip sonidoAtacar;

    [Header("🎵 Sonidos de recolección")]
    public AudioClip sonidoFlor;
    public AudioClip sonidoChocolate;
    public AudioClip sonidoItemFinal;

    private AudioSource audioSource;

    void Awake()
    {
        // Aseguramos que solo haya un SoundManager activo
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Métodos públicos para reproducir cada tipo de sonido
    public void SonidoCaminar() => ReproducirSonido(sonidoCaminar);
    public void SonidoAtacar() => ReproducirSonido(sonidoAtacar);
    public void SonidoFlor() => ReproducirSonido(sonidoFlor);
    public void SonidoChocolate() => ReproducirSonido(sonidoChocolate);
    public void SonidoItemFinal() => ReproducirSonido(sonidoItemFinal);
}
