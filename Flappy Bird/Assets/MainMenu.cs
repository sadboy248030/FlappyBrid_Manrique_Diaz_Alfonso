using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Cargar la escena del juego (aseg�rate de que est� en el Build Settings)
        SceneManager.LoadScene("Flappy Brid");
    }

    public void Exit()
    {
        Debug.Log("Saliendo de la aplicaci�n GG");
        Application.Quit();

        // Para probar en el editor (no funcionar� en un build, solo en el editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
