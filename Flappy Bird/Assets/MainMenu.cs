using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Método para jugar el juego, cargando la escena principal
    public void Play()
    {
        // Cargar la escena del juego (asegúrate de que "Flappy Brid" esté en el Build Settings)
        SceneManager.LoadScene("Flappy Brid");
    }

    // Método para salir de la aplicación
    public void Exit()
    {
        Debug.Log("Saliendo de la aplicación...");

        // Cerrar la aplicación en una compilación
        Application.Quit();

#if UNITY_EDITOR
        // Solo para el editor de Unity (no afecta builds)
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
