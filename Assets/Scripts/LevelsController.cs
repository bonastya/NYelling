using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnLevelButton()
    {
        SceneManager.LoadScene("Level1");
    }


}
