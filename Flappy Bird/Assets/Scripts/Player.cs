using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 startPosition;
    public float gravity = -9.8f;
    public float strength = 5f;

    private GameManager gameManager;
    private Animator animator; // Referencia al Animator

    private bool isDead = false; // El jugador comienza vivo

    // Añadir una variable para guardar el tamaño original
    private Vector3 originalScale;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); // Asocia el GameManager al inicio
        animator = GetComponent<Animator>(); // Obtiene el Animator

        // Guardar el tamaño original del jugador
        originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        // Resetea la posición y dirección del jugador
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;

        // Resetea el Animator y estado
        animator.ResetTrigger("Fly"); // Resetea el trigger de vuelo
        animator.ResetTrigger("Death"); // Resetea el trigger de muerte
        animator.Play("Idle");

        isDead = false; // Asegúrate de que el estado "isDead" esté en false al comenzar
        transform.localScale = originalScale; // Restaurar la escala original
    }

    private void Start()
    {
        startPosition = transform.position;  // Guardar la posición inicial
    }

    private void Update()
    {
        // Control para evitar acciones si el jugador está muerto
        if (isDead) return;

#if UNITY_STANDALONE || UNITY_EDITOR
        // Control por teclado o mouse para PC
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            animator.SetTrigger("Fly"); // Cambia a la animación de vuelo
        }
#elif UNITY_ANDROID || UNITY_IOS
        // Control táctil para dispositivos móviles
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                animator.SetTrigger("Fly"); // Cambia a la animación de vuelo
            }
        }
#endif

        // Aplica la gravedad y mueve al jugador
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Cambia a la animación de "Death" si cae demasiado
        if (transform.position.y < -5f && !isDead) // Verifica si ya no está muerto
        {
            TriggerDeath(); // Llama al método para manejar la muerte
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !isDead) // Verifica si el jugador no está muerto
        {
            TriggerDeath(); // Llama al método para manejar la muerte
        }
        else if (other.CompareTag("Scoring"))
        {
            gameManager.IncreaseScore(); // Incrementa la puntuación
        }
    }

    private void TriggerDeath()
    {
        if (isDead) return; // Evita múltiples activaciones de muerte

        isDead = true; // Marca al jugador como muerto
        animator.SetTrigger("Death"); // Activa el trigger de muerte
        animator.ResetTrigger("Fly"); // Resetea el trigger de vuelo

        // Cambia la escala solo cuando el jugador muere
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Ajusta el valor según lo necesites

        // Llamamos al método OnPlayerDeath para contar la muerte y mostrar el anuncio
      

        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(0.2f);  // Espera 0.2 segundos para dar tiempo a la animación de muerte
        gameManager.GameOver(); // Llama al GameOver en el GameManager
    }

    // Método para restablecer al jugador (llamado en GameManager)
    public void ResetPlayer()
    {
        // Resetea la posición del jugador a la inicial
        transform.position = startPosition;

        // Resetea el estado de las animaciones
        animator.ResetTrigger("Fly"); // Resetea el trigger de vuelo
        animator.ResetTrigger("Death"); // Resetea el trigger de muerte
        animator.Play("Idle"); // Vuelve a la animación Idle

        // Restaurar la escala original
        transform.localScale = originalScale;

        // Resetea el estado de muerte
        isDead = false;

        // Si tienes otros estados o propiedades (por ejemplo, velocidad, salud), también puedes restablecerlas aquí
    }
}
