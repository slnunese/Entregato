using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAttack2D : MonoBehaviour
{
    public float speed = 130f;
    public float attackRange = 0.5f;        // Radio del golpe
    public Transform attackPoint;           // Punto de origen del ataque
    public LayerMask enemyLayer;            // Capa de enemigos
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool atacando = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (atacando) return;

        // Movimiento
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // Ataque con Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Atacar());
        }
    }

    void FixedUpdate()
    {
        if (!atacando)
        {
            rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator Atacar()
    {
        atacando = true;
        animator.SetBool("Atacando", true);

        // Pequeño retardo antes del golpe (sincronizado con animación)
        yield return new WaitForSeconds(0.1f);

        // Detectar enemigos en el rango de ataque
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemigo in enemigosGolpeados)
        {
            // Si el enemigo tiene el tag correcto, lo destruye
            if (enemigo.CompareTag("Enemigo"))
            {
                Destroy(enemigo.gameObject);
            }
        }

        // Esperar a que termine la animación
        yield return new WaitForSeconds(0.4f);

        animator.SetBool("Atacando", false);
        atacando = false;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el rango de ataque en la escena (solo visible en el editor)
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
