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
        UnityEditor.EditorApplication.isPlaying = false;
#else
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // En m�viles, puedes mostrar un mensaje o hacer otra acci�n
            Debug.Log("Saliendo de la aplicaci�n...");
            Application.Quit();
        }
        else
        {
            // En PC o Mac, salir normalmente
            Application.Quit();
        }
#endif
    }

    // M�todo para ir a los cr�ditos
    public void GoToCredits()
    {
        // Cargar la escena de cr�ditos (aseg�rate de que el nombre coincide con el de la escena)
        SceneManager.LoadScene("Credits");
    }
}
