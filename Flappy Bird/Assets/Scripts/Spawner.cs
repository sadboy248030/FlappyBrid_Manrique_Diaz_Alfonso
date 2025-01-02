using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        // Comienza a invocar el método Spawn a intervalos regulares
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Cancela la invocación de Spawn cuando el objeto se desactiva
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Instancia el prefab de los tubos en la posición del spawner
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Ajusta la posición en Y de los tubos en un rango aleatorio
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

#if UNITY_ANDROID || UNITY_IOS
            spawnRate = 1.5f; // Generación más lenta en móvil
#else
        spawnRate = 1f; // Generación más rápida en PC
#endif
    }
}
