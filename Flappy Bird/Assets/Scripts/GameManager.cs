using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;           // Referencia al jugador
    public Text scoreText;          // Referencia al texto del marcador
    public GameObject gameOver;     // Referencia al panel de Game Over
    public GameObject exitButton;   // Referencia al botón de salida
    public GameObject retryButton;  // Referencia al botón de reinicio
    public AdManager adManager;     // Referencia al AdManager

    private int score;              // Puntuación del jugador
    private int deathCount = 0;      // Contador de muertes
    private int minDeaths = 3;       // Número mínimo de muertes para mostrar el anuncio
    private int maxDeaths = 5;       // Número máximo de muertes para mostrar el anuncio

    // Referencias para los sonidos
    public AudioClip gameOverSound;
    public AudioClip scoreSound;
    private AudioSource audioSource;

    private bool isWaitingForAd = false; // Bandera para esperar a que termine un anuncio

    private void Awake()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();

        gameOver.SetActive(false);  // Ocultar Game Over al inicio
        exitButton.SetActive(false);
        retryButton.SetActive(false);

        // Asegúrate de que el AdManager está referenciado

        StartGame();
    }

    private void StartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        exitButton.SetActive(false);
        retryButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        // Destruir tubos existentes
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        deathCount = 0; // Resetea el contador de muertes al inicio del juego
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        exitButton.SetActive(true);
        retryButton.SetActive(true);
        Pause();

        audioSource.PlayOneShot(gameOverSound);

        // Incrementar el contador de muertes
        deathCount++;

        // Verificar si el número de muertes está en el rango de 3-5
        if (deathCount >= minDeaths && deathCount <= maxDeaths)
        {
            // Mostrar el anuncio
            if (adManager != null && !isWaitingForAd)
            {
                isWaitingForAd = true;
                adManager.ShowAd(); // Mostrar el anuncio
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        audioSource.PlayOneShot(scoreSound);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Home Menu");
        
    }

    public void RetryGame()
    {
        if (adManager != null && !isWaitingForAd)
        {
            RestartGame();
        }
        else if (isWaitingForAd)
        {
            // Si estamos esperando un anuncio, no reiniciamos hasta que se haya cerrado el anuncio
            isWaitingForAd = false;
        }
    }

    public void OnAdClosed()
    {
        if (isWaitingForAd)
        {
            isWaitingForAd = false;
            RestartGame();
        }
    }

    private void RestartGame()
    {
        gameOver.SetActive(false);
        exitButton.SetActive(false);
        retryButton.SetActive(false);

        score = 0;
        scoreText.text = score.ToString();

        player.enabled = true;
        player.ResetPlayer();

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        Time.timeScale = 1f;
    }

#if UNITY_ANDROID || UNITY_IOS
    public void OnExitButtonClicked()
    {
        ExitToMenu();
    }

    public void OnRetryButtonClicked()
    {
        RetryGame();
    }
#elif UNITY_STANDALONE || UNITY_EDITOR
    public void OnExitButtonClicked()
    {
        ExitToMenu();
    }

    public void OnRetryButtonClicked()
    {
        RetryGame();
    }
#endif
}
