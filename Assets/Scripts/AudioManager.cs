using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgm;
    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayBgm()
    {
        bgm.Play();
    }
    public void stopBgm()
    {
        bgm.Stop();
    }

    public void PlaySfx(int sfxNo)
    {
        sfx[sfxNo].Stop();
        sfx[sfxNo].Play();
    }

    public void StopSfx(int sfxNo)
    {
        sfx[sfxNo].Stop();
    }
}
