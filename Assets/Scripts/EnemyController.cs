using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 2f;
    public float rangoDeteccion = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= rangoDeteccion)
        {
            Vector2 direccion = (jugador.position - transform.position).normalized;
            rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("💥 El enemigo atrapó al jugador. GAME OVER");

            // Buscar el GameOverManager
            if (GameOverManager.instance != null)
            {
                GameOverManager.instance.MostrarGameOver();
            }
            else
            {
                // Si no lo encuentra, recarga la escena
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
