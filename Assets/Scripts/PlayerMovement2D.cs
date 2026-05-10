using UnityEngine;
using System.Collections; // Necesario para IEnumerator

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 130f;        // Velocidad del jugador
    public Animator animator;       // Controlador de animaciones

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool atacando = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;       // Evita que caiga
        rb.freezeRotation = true;   // Evita rotaciones raras
    }

    void Update()
    {
        // Si está atacando, no se mueve
        if (atacando) return;

        // Movimiento: WASD o flechas
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Actualiza parámetros de animación
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // Ataque con la tecla Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Atacar());
        }

        if (moveInput != Vector2.zero && !SoundManager.instance.GetComponent<AudioSource>().isPlaying)
    {
        SoundManager.instance.SonidoCaminar();
    }

    if (Input.GetKeyDown(KeyCode.Z))
    {
        SoundManager.instance.SonidoAtacar();
    }
    }

    void FixedUpdate()
    {
        // Movimiento físico (solo si no está atacando)
        if (!atacando)
        {
            rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator Atacar()
    {
        atacando = true;
        animator.SetBool("Atacando", true);

        // Espera la duración de la animación de ataque (ajusta el tiempo según tu animación)
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("Atacando", false);
        atacando = false;
    }
}
