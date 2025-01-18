using System.Collections;
using UnityEngine;
using TMPro;

public class CreditsTextAnimation : MonoBehaviour
{
    public TextMeshProUGUI creditsText; // Referencia al componente TextMeshProUGUI
    public float moveSpeed = 50f; // Velocidad de movimiento hacia abajo
    public float destroyDelay = 1f; // Tiempo entre la destrucción del texto y la siguiente acción
    public float startOffset = 100f; // Desplazamiento inicial antes de empezar a mover el texto

    private RectTransform rectTransform;

    // Usamos OnEnable para que la animación se ejecute cada vez que se activa el objeto
    void OnEnable()
    {
        // Verifica si el TextMeshProUGUI está asignado
        if (creditsText == null)
        {
            return;
        }

        // Obtenemos el RectTransform del texto
        rectTransform = creditsText.GetComponent<RectTransform>();

        // Reseteamos la posición para que empiece desde el inicio
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, startOffset);

        // Iniciar la animación
        StartCoroutine(MoveTextDown());
    }

    private IEnumerator MoveTextDown()
    {
        // Mover el texto hacia abajo hasta que salga de la pantalla
        while (rectTransform.anchoredPosition.y > -Screen.height)
        {
            rectTransform.anchoredPosition += Vector2.down * moveSpeed * Time.deltaTime;
            yield return null;
        }

        // Destruir el objeto de texto después de haber salido de la pantalla
        Destroy(creditsText.gameObject, destroyDelay);
    }
}
