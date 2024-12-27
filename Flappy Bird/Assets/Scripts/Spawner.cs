using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
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

#if UNITY_STANDALONE || UNITY_EDITOR
        // En PC y Editor, puedes ajustar la velocidad de generaci�n de los tubos si lo necesitas
        // Si no necesitas cambios espec�ficos para PC, esta parte podr�a no ser necesaria.
#elif UNITY_ANDROID || UNITY_IOS
        // En m�vil, puedes ajustar la tasa de generaci�n o la posici�n si es necesario
        // Esta secci�n tambi�n puede ser vac�a si no hay cambios espec�ficos para m�viles.
#endif
    }
}
