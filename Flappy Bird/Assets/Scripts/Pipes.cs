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

#if UNITY_STANDALONE || UNITY_EDITOR
        // En PC y Editor, simplemente destruye los objetos cuando salen de la pantalla
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
#elif UNITY_ANDROID || UNITY_IOS
        // En móvil también destruimos los objetos fuera de la pantalla
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
#endif
    }
}
