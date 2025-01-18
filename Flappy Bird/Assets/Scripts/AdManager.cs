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

    // Método llamado cuando la inicialización de los anuncios ha finalizado
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads Inicialización completada.");
        // Cargar el anuncio intersticial
        Advertisement.Load(interstitialAdID, this);
    }

    // Método llamado si la inicialización de los anuncios falla
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
      //  Debug.LogError("Unity Ads Inicialización fallida: " + message);
    }

    // Método llamado cuando el anuncio se ha cargado correctamente
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Anuncio cargado: " + placementId);
    }

    // Método llamado cuando el anuncio no pudo cargarse
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError("Error al cargar el anuncio: " + message);
    }

    // Método que se llama cuando se hace clic en el anuncio
    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Anuncio mostrado: " + placementId);
    }

    // Método llamado cuando se ha completado la visualización del anuncio
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

    // Método llamado si el anuncio falla al mostrarse
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Error al mostrar el anuncio: " + message);
    }

    // Método llamado cuando el anuncio comienza a mostrarse
    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Anuncio comenzado: " + placementId);
    }

    // Método para mostrar el anuncio intersticial
    public void ShowAd()
    {
        // Verificar si los anuncios están listos y si la inicialización fue exitosa
        if (Advertisement.isInitialized)
        {
            // Mostrar el anuncio intersticial
            Advertisement.Show(interstitialAdID, this);
        }
        else
        {
            Debug.Log("Los anuncios no están listos para mostrarse.");
        }
    }
}
