using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private bool _isLoading;
    
    

    public void OnMarketButton()
    {
        LoadScene("MarketScene");
    }
    public void OnTasksButton()
    {
        LoadScene("TasksScene");
    }
    public void OnSettingsButton()
    {
        LoadScene("SettingsScene");
    }

    public void OnAboutUsButton()
    {
        LoadScene("AboutUsScene");
    }

    public void OnLevelsModeButton()
    {
        LoadScene("LevelsScene");
    }

    public void OnChooseModeButton()
    {
        LoadScene("ModeScene");
    }

    public void OnBackToMenuButton()
    {
        LoadScene("MenuScene");
    }

    public void OnP1L1Button()
    {
        print("клик");
        LoadScene("P1L1");
    }

    public void OnLoading()
    {
        LoadScene("MenuScene");
    }

    private void LoadScene(string SceneName)
    {
        if (_isLoading)
            return;

        StartCoroutine(LoadSceneRoutine(SceneName));
    }


    public IEnumerator LoadSceneRoutine(string SceneName)
    {
        _isLoading = true;

        var waitFading = true;
        Fader.instance.gameObject.SetActive(true);

        Fader.instance.FadeIn(() => waitFading = false);

        while (waitFading)
            yield return null;

        SceneManager.LoadScene(SceneName);

        waitFading = true;
        Fader.instance.FadeOut(() => waitFading = false);

        while (waitFading)
            yield return null;


        _isLoading = false;
    }






}
