using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfx;
    public AudioClip[] musicclips;

    // Start is called before the first frame update
    void Start()
    {
        music.Play();
        music.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.clip = clip;
        sfx.Play();
    }

    public void PlayMusic(int clip)
    {
        music.clip = musicclips[clip];
        music.Play();
    }

}
