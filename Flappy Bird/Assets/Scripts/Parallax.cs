using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);

#if UNITY_ANDROID || UNITY_IOS
            animationSpeed = 0.5f; // Menor velocidad en móviles
#else
        animationSpeed = 1f; // Velocidad normal en PC
#endif
    }
}
