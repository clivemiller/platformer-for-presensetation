using UnityEngine;
using UnityEngine.UI;

public class YouWinManager : MonoBehaviour
{
    public Text winText;

    void Start()
    {
        winText.gameObject.SetActive(false);
    }

    public void Win()
    {
        winText.gameObject.SetActive(true);
    }
}
