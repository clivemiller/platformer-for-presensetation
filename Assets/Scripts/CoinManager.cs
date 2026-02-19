using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    int CoinCount = 0;

    [Header("Audio")]
    [SerializeField] private AudioClip collectSound;

    public Text coinText;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void CountIncrement()
    {
        CoinCount++;
        coinText.text = "Coins: " + CoinCount.ToString();
        Debug.Log("Coins collected: " + CoinCount);

        if (collectSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collectSound);
        }
    }
}
