using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Cambia al índice de tu menú principal
    }
}
