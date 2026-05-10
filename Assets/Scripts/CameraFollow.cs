using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // El jugador (u objeto a seguir)
    public float smoothSpeed = 5f;  // Velocidad con la que la cámara sigue al jugador
    public Vector3 offset;     // Separación entre la cámara y el jugador

    void LateUpdate()
    {
        if (target == null) return;

        // Posición deseada = posición del jugador + desplazamiento
        Vector3 desiredPosition = target.position + offset;

        // Movimiento suave entre posición actual y deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;
    }
}
