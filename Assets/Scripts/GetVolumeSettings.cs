using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GetVolumeSettings : MonoBehaviour
{
    void Start()
    { 
        Sound[] sounds = FindObjectOfType<AudioManager>().sounds;
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        
        s.source.volume = PlayerPrefs.GetInt("musicOn", 1) == 1 ? 0.3f : 0;

        AudioListener.volume = PlayerPrefs.GetInt("soundOn", 1) == 0 ? 0 : 1;
    }
}
