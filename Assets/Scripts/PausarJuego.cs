using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{
    private bool juegoPausado = false;

    // 🔹 Este método alterna entre pausar y reanudar
    public void TogglePause()
    {
        if (juegoPausado)
        {
            ReanudarJuego();
        }
        else
        {
            PausarJuegoFuncion();
        }
    }

    // 🔹 Pausa el juego
    private void PausarJuegoFuncion()
    {
        Time.timeScale = 0f; // Detiene el tiempo
        juegoPausado = true;
        Debug.Log("Juego pausado");
    }

    // 🔹 Reanuda el juego
    private void ReanudarJuego()
    {
        Time.timeScale = 1f; // Restaura el tiempo
        juegoPausado = false;
        Debug.Log("Juego reanudado");
    }

    // 🔹 Vuelve al menú principal
    public void VolverAlMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo esté normal
        SceneManager.LoadScene("Menu"); // Cambia "Menu" por el nombre exacto de tu escena de menú
    }
}
