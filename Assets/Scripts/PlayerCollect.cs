using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private int floresRecogidas = 0;
    private int chocolatesRecogidos = 0;

    [Header("Totales de ítems")]
    public int floresTotales = 5;
    public int chocolatesTotales = 5;

    [Header("Carta final")]
    public GameObject cartaFinal; // Asigna la carta en el inspector

    void Start()
    {
        // Oculta la carta al inicio
        if (cartaFinal != null)
            cartaFinal.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador toca una flor
        if (collision.CompareTag("flor"))
        {
            floresRecogidas++;
            Debug.Log("🌸 Flores recogidas: " + floresRecogidas + "/" + floresTotales);
            
            // Reproducir sonido
            if (SoundManager.instance != null)
                SoundManager.instance.SonidoFlor();

            Destroy(collision.gameObject);
            RevisarObjetos();
        }

        // Si el jugador toca un chocolate
        else if (collision.CompareTag("Chocolate"))
        {
            chocolatesRecogidos++;
            Debug.Log("🍫 Chocolates recogidos: " + chocolatesRecogidos + "/" + chocolatesTotales);

            // Reproducir sonido
            if (SoundManager.instance != null)
                SoundManager.instance.SonidoChocolate();

            Destroy(collision.gameObject);
            RevisarObjetos();
        }
    }

    private void RevisarObjetos()
    {
        // Si ya recogió todas las flores y chocolates
        if (floresRecogidas >= floresTotales && chocolatesRecogidos >= chocolatesTotales)
        {
            if (cartaFinal != null)
            {
                cartaFinal.SetActive(true);
                Debug.Log("💌 ¡Has recogido todo! La carta ha aparecido.");

                // Sonido de carta final
                if (SoundManager.instance != null)
                    SoundManager.instance.SonidoItemFinal();
            }
        }
    }
}
