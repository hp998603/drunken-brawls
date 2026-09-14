using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private Material backgroundMaterial;

    void Start()
    {
        // Get the material from the Quad's renderer
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calculate the new X offset based on time and speed
        float xOffset = Time.time * scrollSpeed;
        
        // Apply the offset to the main texture
        backgroundMaterial.mainTextureOffset = new Vector2(xOffset, 0);
    }
}
