using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    int currentMusic = 0;
    AudioSource audioSource;
    public AudioClip[] clipNames;
    public TextMeshProUGUI musicName;
    public Slider musicLength;
    private bool stop = false;

    
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        StartAudio();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
        {
            musicLength.value += Time.deltaTime;
            if(musicLength.value >= audioSource.clip.length )
            {
                currentMusic++;
                if(currentMusic >= clipNames.Length )
                {
                    currentMusic = 0;
                }
                StartAudio();
            }
        }
    }

    public void StartAudio(int changeMusic = 0)
    {
        currentMusic += changeMusic;
        if(currentMusic >= clipNames.Length) 
        {
            currentMusic = 0;
        }
        else if(currentMusic < 0)
        {
            currentMusic = clipNames.Length - 1;
        }
        if(audioSource.isPlaying && changeMusic == 0) 
        {
            return;
        }
        if(stop)
        {
            stop = false;
        }
        audioSource.clip = clipNames[currentMusic];
        musicName.text = audioSource.clip.name;
        musicLength.maxValue = audioSource.clip.length;
        musicLength.value = 0;
        audioSource.Play();
    }

    public void StopAudio() 
    {
        audioSource.Stop();
        stop = true;
    }
}
