using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider sound;
    [SerializeField] private Slider music;

    public int soundOn = 1;
    public int musicOn = 1;

    private void Start()
    {
         soundOn = PlayerPrefs.GetInt("soundOn", 1);
         musicOn = PlayerPrefs.GetInt("musicOn", 1);
         ApplySettings();
    }
    
    public void Sound()
    {
        soundOn = (int)sound.value;
        ApplySettings();
    }

    public void Music()
    {
        musicOn = (int)music.value;
        ApplySettings();
    }

    private void ApplySettings()
    {
        music.value = musicOn;
        sound.value = soundOn;
        
        PlayerPrefs.SetInt("soundOn", soundOn);
        PlayerPrefs.SetInt("musicOn", musicOn);

        Sound[] sounds = FindObjectOfType<AudioManager>().sounds;
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        
        s.source.volume = musicOn == 1 ? 0.3f : 0;

        AudioListener.volume = soundOn == 0 ? 0 : 1;
    }
}
