using UnityEngine;

public class FadingWall : MonoBehaviour
{
    public Material transparentMaterial;
    private Material originalMaterial;
    private MeshRenderer meshRenderer;
    private bool isFaded = false;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    public void FadeOut()
    {
        if (isFaded) return;
        meshRenderer.material = transparentMaterial;
        isFaded = true;
    }

    public void FadeIn()
    {
        if (!isFaded) return;
        meshRenderer.material = originalMaterial;
        isFaded = false;
    }
}