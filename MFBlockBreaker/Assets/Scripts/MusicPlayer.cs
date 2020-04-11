using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.Play();
        backgroundMusic.loop = true;
        //Music must keep playing throughout the other scenes too.
        DontDestroyOnLoad(gameObject);
    }
}
