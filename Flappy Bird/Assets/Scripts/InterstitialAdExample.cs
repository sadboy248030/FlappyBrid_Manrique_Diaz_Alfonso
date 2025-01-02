using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    private string _adUnitId;

    void Awake()
    {
        // Seleccionar el ID de anuncios según la plataforma
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    public void ShowAd()
    {
        Debug.Log("Intentando mostrar el anuncio: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    // Implementación de métodos de interfaz para manejar los eventos de anuncios
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log($"Anuncio cargado: {adUnitId}");
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error cargando el anuncio: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId == _adUnitId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Anuncio completado con éxito.");
            FindObjectOfType<GameManager>().OnAdClosed(); // Llamar al GameManager cuando termine el anuncio
        }
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error mostrando el anuncio: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId)
    {
        Debug.Log($"Anuncio iniciado: {adUnitId}");
    }

    public void OnUnityAdsShowClick(string adUnitId)
    {
        Debug.Log($"Anuncio clicado: {adUnitId}");
    }
}
