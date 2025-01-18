using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // Ajusta la velocidad solo una vez al inicio según la plataforma
#if UNITY_ANDROID || UNITY_IOS
        speed = 3f; // Velocidad reducida para móviles
#else
            speed = 5f; // Velocidad normal en PC
#endif

        // Calcular la posición de borde izquierdo de la cámara
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Mueve los tubos a la izquierda con la velocidad establecida
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destruir los tubos cuando salgan fuera de la pantalla
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
