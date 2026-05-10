using UnityEngine;
using UnityEngine.UI;

public class ItemCounterUI : MonoBehaviour
{
    [Header("Flor")]
    public Image[] floresIcons;
    private int totalFlores;
    private int floresRestantes;

    [Header("Chocolates")]
    public Image[] chocolatesIcons;
    private int totalChocolates;
    private int chocolatesRestantes;

    [Header("Carta final")]
    public GameObject cartaFinal; // Objeto de la carta (debe estar desactivado al inicio)

    [Header("Colores")]
    public Color colorObtenido = Color.white;
    public Color colorFaltante = new Color(1f, 1f, 1f, 0.3f);

    private bool cartaMostrada = false;

    void Start()
    {
        // Contar los objetos existentes al inicio
        totalFlores = GameObject.FindGameObjectsWithTag("Flor").Length;
        totalChocolates = GameObject.FindGameObjectsWithTag("Chocolate").Length;
        floresRestantes = totalFlores;
        chocolatesRestantes = totalChocolates;

        if (cartaFinal != null)
            cartaFinal.SetActive(false); // Oculta la carta al principio

        ActualizarUI();
    }

    void Update()
    {
        // Contar objetos en tiempo real
        int floresActuales = GameObject.FindGameObjectsWithTag("Flor").Length;
        int chocolatesActuales = GameObject.FindGameObjectsWithTag("Chocolate").Length;

        // Si hay un cambio en las flores
        if (floresActuales < floresRestantes)
        {
            floresRestantes = floresActuales;
            if (SoundManager.instance != null)
                SoundManager.instance.SonidoFlor(); // 🎵 Sonido al recoger flor
            ActualizarUI();
        }

        // Si hay un cambio en los chocolates
        if (chocolatesActuales < chocolatesRestantes)
        {
            chocolatesRestantes = chocolatesActuales;
            if (SoundManager.instance != null)
                SoundManager.instance.SonidoChocolate(); // 🎵 Sonido al recoger chocolate
            ActualizarUI();
        }

        // Si ya no quedan objetos y la carta no se ha mostrado
        if (!cartaMostrada && floresRestantes == 0 && chocolatesRestantes == 0)
        {
            MostrarCartaFinal();
        }
    }

    private void ActualizarUI()
    {
        int floresRecogidas = totalFlores - floresRestantes;
        int chocolatesRecogidos = totalChocolates - chocolatesRestantes;

        // Actualizar íconos de flores
        for (int i = 0; i < floresIcons.Length; i++)
        {
            floresIcons[i].color = (i < floresRecogidas) ? colorObtenido : colorFaltante;
        }

        // Actualizar íconos de chocolates
        for (int i = 0; i < chocolatesIcons.Length; i++)
        {
            chocolatesIcons[i].color = (i < chocolatesRecogidos) ? colorObtenido : colorFaltante;
        }
    }

    private void MostrarCartaFinal()
    {
        cartaMostrada = true;
        if (cartaFinal != null)
        {
            cartaFinal.SetActive(true);
            Debug.Log("🎴 ¡Has recogido todos los ítems! Carta final activada.");

            if (SoundManager.instance != null)
                SoundManager.instance.SonidoItemFinal(); // 🎵 Sonido del ítem final
        }
    }
}
