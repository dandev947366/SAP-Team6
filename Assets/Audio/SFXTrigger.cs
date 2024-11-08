using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    public AudioController audiControll;
    private GameObject audioManager;
    public AudioClip clipToPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        audiControll = audioManager.GetComponent<AudioController>();
    }


    public void InitiateSFX()
    {
        audiControll.PlaySFX(clipToPlay);
    }
}
