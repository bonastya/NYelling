using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    public Image loadingBG;

    public Sprite[] bgs;

    public MenuController mc;

    void Start()
    {
        loadingBG.sprite = bgs[Random.Range(0, bgs.Length-1)];
        StartCoroutine(LoadingAnim());

    }

    public IEnumerator LoadingAnim()
    {

        yield return new WaitForSeconds(3.5f);
        mc.OnLoading();
    }

}
