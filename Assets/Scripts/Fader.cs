using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{

    private const string FADE_PATH = "Fader";
    private static Fader _instance;

    [SerializeField] private Animator animator;

    public AudioSource myFx;
    public AudioClip clickSound;

    public void ClickSound()
    {
        myFx.PlayOneShot(clickSound);
    }


    public static Fader instance
    {
        get
        {
            if (_instance == null)
            {
                var prefab = Resources.Load<Fader>(FADE_PATH);
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public bool isFading { get; private set; }

    private Action _fadedInCallback;
    private Action _fadedOutCallback;


    public void FadeIn(Action fadedInCallback)
    {
        ClickSound();

        if (isFading)
            return;

        isFading = true;
        _fadedInCallback = fadedInCallback;
        animator.SetBool("Faded", true);

    }

    public void FadeOut(Action fadedOutCallback)
    {

        if (isFading)
            return;

        isFading = true;
        _fadedOutCallback = fadedOutCallback;
        animator.SetBool("Faded", false);

    }


    private void Handle_HadeInAnimationOver()
    {
        _fadedInCallback?.Invoke();
        _fadedInCallback = null;
        isFading = false;
    }

    private void Handle_HadeOutAnimationOver()
    {
        _fadedOutCallback?.Invoke();
        _fadedOutCallback = null;
        isFading = false;
        _instance.gameObject.SetActive(false);
    }









}
