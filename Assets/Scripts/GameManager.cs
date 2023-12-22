using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float moveSpeed, rotateSpeed;
    public GameObject gameOverPanel;
    public GameObject gamePanel;
    public GameObject menuPanel;

    [SerializeField] TextMeshProUGUI volumeText;
    //[SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] TextMeshProUGUI moneyText;
    //public GameObject startPause;

    public GameObject good;
    public GameObject notGood;



    public bool isGameStart = false;
    public double score=0;
    public double money=0;

    

    public float maxVolume = 7f;




    void Start()
    {
        //isGameStart = true;

        menuPanel.SetActive(true);
        StartCoroutine(VolCor());
    }


    void Update()
    {
        //scoreText.text = "Score: " + score;
        
        //moneyText.text = "Money: " + money;
        //moneyText.text = money.ToString();

    }

    IEnumerator VolCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            volumeText.text = "Volume: " + (Math.Round(MicInput.MicLoudness * 10, 1));
            //volumeText.text = "Volume: " + (((float)MicInput.MicLoudness)*10 * 5 / maxVolume);
        }


    }

    public void OnPlayButtonClick()
    {
        CleanScreen();
        
        isGameStart = true;
    }
    public void OnPause1ButtonClick()
    {
        if (isGameStart)
        {
            //startPause.SetActive(false);
            isGameStart = false; 
        }
        else
        {
            //startPause.SetActive(true);
            isGameStart = true;
        }
        
    }

    public void GameOver(int levelCompleted)
    {
        isGameStart = false;
        gameOverPanel.SetActive(true);
        if (levelCompleted == 0)
        {
            notGood.SetActive(true);
            good.SetActive(false);
        }
        else
        {
            notGood.SetActive(false);
            good.SetActive(true);
        }

    }
    public void OnReplayButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        CleanScreen();
    }



    private void CleanScreen()
    {
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
