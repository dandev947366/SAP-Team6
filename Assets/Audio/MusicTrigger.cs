using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioController audiControll;
    private GameObject audioManager;
    public int ClipToPlay;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        audiControll = audioManager.GetComponent<AudioController>();
    }

    public void InitiateMusic(int Clip)
    {
        Clip = ClipToPlay;
        audiControll.PlayMusic(Clip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
