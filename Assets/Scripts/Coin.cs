using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Hover Settings")]
    [SerializeField] private float hoverSpeed = 2f;
    [SerializeField] private float hoverHeight = 0.5f;

    [Header("Popup Settings")]
    [SerializeField] private float popupForce = 5f;
    [SerializeField] private float popupDuration = 0.3f;

    
    private Vector3 startPosition;
    private bool isCollected = false;
    private AudioSource audioSource;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isCollected)
        {
            // Hover up and down using sine wave
            float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
            transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the "Player" tag
        if (other.CompareTag("player") && !isCollected)
        {
            isCollected = true;
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        CoinManager coinManager = FindFirstObjectByType <CoinManager>();
        coinManager.CountIncrement();

        // Start popup animation
        StartCoroutine(PopupAndDisappear());
    }

    private System.Collections.IEnumerator PopupAndDisappear()
    {
        // Disable collider so it can't be collected again
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Popup effect
        Vector3 originalScale = transform.localScale;
        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < popupDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / popupDuration;

            // Scale up and fade out effect
            transform.localScale = originalScale * (1f + progress * 0.5f);
            transform.position = startPos + Vector3.up * (progress * popupForce);

            yield return null;
        }

        // Destroy the coin
        Destroy(gameObject);
    }
}
