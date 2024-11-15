using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int level = 1;

    protected virtual void Start()
    {
        // Inisialisasi jika diperlukan
    }

    protected virtual void Update()
    {
        // Logika per frame untuk Enemy umum
    }

    protected void DestroyIfOffScreen()
    {
        if (!RendererIsVisible())
        {
            Destroy(gameObject);
        }
    }

    private bool RendererIsVisible()
    {
        var renderer = GetComponent<Renderer>();
        return renderer.isVisible;
    }
}
