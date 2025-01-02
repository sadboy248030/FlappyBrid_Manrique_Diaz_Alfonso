using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // M�todo para jugar el juego, cargando la escena principal
    public void Play()
    {
        // Cargar la escena del juego (aseg�rate de que "Flappy Brid" est� en el Build Settings)
        SceneManager.LoadScene("Flappy Brid");
    }

    // M�todo para salir de la aplicaci�n
    public void Exit()
    {
        Debug.Log("Saliendo de la aplicaci�n...");

        // Cerrar la aplicaci�n en una compilaci�n
        Application.Quit();

#if UNITY_EDITOR
        // Solo para el editor de Unity (no afecta builds)
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
