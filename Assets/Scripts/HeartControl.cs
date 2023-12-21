using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartControl : MonoBehaviour
{
    [Header("Health Control")]
    //start number of lives
    public int StartHarts;

    //panel and sprite of lives
    public GameObject heartPanel;
    public Sprite heartSprite;

    //current number of lives
    private int heartsNum;

    private List<GameObject> hearts = new List<GameObject>();
    private float offset = 50;


    public GameObject gameOverPanel;
    public GameObject gamePanel;

    void Start()
    {
        //spawn hearts by the number of StartHarts
        for (int i = 0; i < StartHarts; i++)
        {
            GameObject imgObject = new GameObject("Heart");
            RectTransform trans = imgObject.AddComponent<RectTransform>();
            trans.transform.SetParent(heartPanel.transform);

            trans.anchoredPosition = new Vector2(-offset * i, 0f);
            trans.sizeDelta = new Vector2(50, 50);
            Image image = imgObject.AddComponent<Image>();

            image.sprite = heartSprite;

            hearts.Add(imgObject);
        }

        heartsNum = hearts.Count;
    }

    public void HealthDecrease()
    {
        hearts[heartsNum - 1].SetActive(false);
        heartsNum--;
        if (heartsNum <= 0)
        {
            Die();
        }
    }

    public void HealthIncrease()
    {
        hearts[heartsNum].SetActive(true);
        heartsNum++;
    }

    void Die()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 0;

    }

}
