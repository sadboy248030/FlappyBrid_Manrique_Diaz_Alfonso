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
        UnityEditor.EditorApplication.isPlaying = false;
#else
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // En móviles, puedes mostrar un mensaje o hacer otra acción
            Debug.Log("Saliendo de la aplicación...");
            Application.Quit();
        }
        else
        {
            // En PC o Mac, salir normalmente
            Application.Quit();
        }
#endif
    }

    // Método para ir a los créditos
    public void GoToCredits()
    {
        // Cargar la escena de créditos (asegúrate de que el nombre coincide con el de la escena)
        SceneManager.LoadScene("Credits");
    }
}
