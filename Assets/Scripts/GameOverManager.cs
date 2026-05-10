using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("Panel de Game Over")]
    public GameObject gameOverPanel; // Asigna el panel en el inspector

    public static GameOverManager instance; // Singleton simple

    void Awake()
    {
        instance = this;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Aseguramos que esté oculto al inicio
    }

    public void MostrarGameOver()
    {
        Time.timeScale = 0f; // Pausa el juego
        gameOverPanel.SetActive(true);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Cambia "Menu" por el nombre exacto de tu escena del menú
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
