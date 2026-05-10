using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Llama a esta función desde un botón del menú
    public void CargarEscenaDeJuego()
    {
        // Cambia "Juego" por el nombre exacto de tu escena del juego
        SceneManager.LoadScene("Juego");
    }

    // (Opcional) Para salir del juego desde un botón
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}

