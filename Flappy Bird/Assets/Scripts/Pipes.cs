using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Mueve los tubos a la izquierda
        transform.position += Vector3.left * speed * Time.deltaTime;

#if UNITY_ANDROID || UNITY_IOS
            speed = 3f; // Velocidad reducida para móviles
#else
        speed = 5f; // Velocidad normal en PC
#endif

        // Destruir objetos fuera de la pantalla
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
