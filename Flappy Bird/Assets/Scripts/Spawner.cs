using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        // Ajusta la tasa de generaci�n seg�n la plataforma solo una vez al principio
#if UNITY_ANDROID || UNITY_IOS
        spawnRate = 1.5f; // Generaci�n m�s lenta en m�viles
#else
            spawnRate = 1f; // Generaci�n m�s r�pida en PC
#endif

        // Comienza a invocar el m�todo Spawn a intervalos regulares
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        // Cancela la invocaci�n de Spawn cuando el objeto se desactiva
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // Instancia el prefab de los tubos en la posici�n del spawner
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Ajusta la posici�n en Y de los tubos en un rango aleatorio
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
