using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        // Ajusta la velocidad según la plataforma solo al iniciar
#if UNITY_ANDROID || UNITY_IOS
        animationSpeed = 0.5f; // Menor velocidad en móviles
#else
            animationSpeed = 1f; // Velocidad normal en PC
#endif
    }

    private void Update()
    {
        // Mueve la textura en el eje X con la velocidad ajustada
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
