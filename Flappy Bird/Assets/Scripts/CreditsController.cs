using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Cambia al �ndice de tu men� principal
    }
}
