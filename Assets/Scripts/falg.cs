using NUnit.Framework;
using UnityEngine;

public class falg : MonoBehaviour
{
    private Vector2 pos;
    private float height;

    public GameObject flag;
    private float flagHeight;
    private float flagWidth;
    private bool levelComplete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
        height = GetComponent<SpriteRenderer>().bounds.size.y;

        flagHeight = flag.GetComponent<SpriteRenderer>().bounds.size.y;
        flagWidth = flag.GetComponent<SpriteRenderer>().bounds.size.x;

        flag.transform.position = new Vector2(pos.x - flagWidth /2, pos.y + height * 7/16 - flagHeight /2);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete)
        {
            float dis = -2f *Time.deltaTime;
            flag.transform.position = new Vector2(flag.transform.position.x, flag.transform.position.y + dis);
        }
        if (flag.transform.position.y < pos.y - height / 2 + flagHeight / 2)
        {
            flag.transform.position = new Vector2(flag.transform.position.x, pos.y - height / 2 + flagHeight / 2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            levelComplete = true;
            Debug.Log("Level Complete!");
            YouWinManager youWinManager = FindFirstObjectByType<YouWinManager>();
            youWinManager.Win();
        }
    }
}
