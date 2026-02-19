using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length;
    private float startpos;

    [Tooltip("Leave empty to auto-use the Main Camera.")]
    public GameObject Camera;

    [Tooltip("0 = no parallax, 1 = moves with camera")]
    [Range(0f, 1f)]
    public float parallaxEffect = 0.5f;

    private Transform cameraTransform;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (Camera != null)
        {
            cameraTransform = Camera.transform;
        }
        else if (UnityEngine.Camera.main != null)
        {
            cameraTransform = UnityEngine.Camera.main.transform;
        }

        if (!TryGetComponent(out spriteRenderer))
        {
            enabled = false;
            return;
        }
    }

    void Start()
    {
        startpos = transform.position.x;
        length = spriteRenderer.bounds.size.x;
    }

    void LateUpdate()
    {
        if (cameraTransform == null || length <= 0f)
        {
            return;
        }

        float camX = cameraTransform.position.x;
        float distance = camX * parallaxEffect;
        float movement = camX * (1f - parallaxEffect);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if (movement > startpos + length)
        {
            startpos += length;
        }
        else if (movement < startpos - length)
        {
            startpos -= length;
        }
    }

    void OnValidate()
    {
        parallaxEffect = Mathf.Clamp01(parallaxEffect);
    }
}
