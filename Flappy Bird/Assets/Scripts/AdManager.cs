using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string androidID = "5761049";
    public string appleID = "5761048";
    public bool testMode = true;

    private string interstitialAdID = "Interstitial_Android"; // ID de tu anuncio intersticial

    void Start()
    {
        // Inicializar Unity Ads
        if (!Advertisement.isInitialized)
        {
#if UNITY_EDITOR || UNITY_ANDROID
            Advertisement.Initialize(androidID, testMode, this);
#elif UNITY_IOS
            Advertisement.Initialize(appleID, testMode, this);
#endif
        }
    }

    // M�todo llamado cuando la inicializaci�n de los anuncios ha finalizado
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Inicializaci�n completada.");
        // Cargar el anuncio intersticial
        Advertisement.Load(interstitialAdID, this);
    }

    // M�todo llamado si la inicializaci�n de los anuncios falla
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
      //  Debug.LogError("Unity Ads Inicializaci�n fallida: " + message);
    }

    // M�todo llamado cuando el anuncio se ha cargado correctamente
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Anuncio cargado: " + placementId);
    }

    // M�todo llamado cuando el anuncio no pudo cargarse
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError("Error al cargar el anuncio: " + message);
    }

    // M�todo que se llama cuando se hace clic en el anuncio
    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Anuncio mostrado: " + placementId);
    }

    // M�todo llamado cuando se ha completado la visualizaci�n del anuncio
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Anuncio visto completamente.");
        }
        else
        {
            Debug.Log("Anuncio no completado.");
        }
    }

    // M�todo llamado si el anuncio falla al mostrarse
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Error al mostrar el anuncio: " + message);
    }

    // M�todo llamado cuando el anuncio comienza a mostrarse
    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Anuncio comenzado: " + placementId);
    }

    // M�todo para mostrar el anuncio intersticial
    public void ShowAd()
    {
        // Verificar si los anuncios est�n listos y si la inicializaci�n fue exitosa
        if (Advertisement.isInitialized)
        {
            // Mostrar el anuncio intersticial
            Advertisement.Show(interstitialAdID, this);
        }
        else
        {
            Debug.Log("Los anuncios no est�n listos para mostrarse.");
        }
    }
}
