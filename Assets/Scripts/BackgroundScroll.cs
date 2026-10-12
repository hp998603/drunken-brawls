using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;

    private Material backgroundMaterial;
    private float xOffset = 0f;
    private Transform targetCamera;

    public bool isScrolling = true;
    public bool Building = false;

    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
        targetCamera = Camera.main.transform;
    }

    void Update()
    {
        if (isScrolling)
        {
            // Increase offset only while we're moving
            xOffset += scrollSpeed * Time.deltaTime;

            backgroundMaterial.mainTextureOffset =
                new Vector2(xOffset, 0);

            if (Building)
            {
                // go to camera's x and z position
                Vector3 targetPosition = new Vector3(
                    targetCamera.position.x - 50f,
                    transform.position.y,
                    transform.position.z
                );

                // move to camera's position
                float step = scrollSpeed*4 * Time.deltaTime;

                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    step
                );
            }
        }
    }

    public void StartScrolling()
    {
        isScrolling = true;
    }

    public void StopScrolling()
    {
        isScrolling = false;
    }
}