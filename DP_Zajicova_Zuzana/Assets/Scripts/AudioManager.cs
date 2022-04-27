using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Sound[] sounds;
    private int soundIndex;
    public SettingsMenu menu;


    public static AudioManager instance;
    void Awake()
    {
        soundIndex = PlayerPrefs.GetInt("Sound", 0);

        if (instance == null)
            instance = this;
        else
        {
           Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }



      


    }

    private void Start()
    {
        if (soundIndex == 0)
        {
            Play("Theme");
        }
        else if (soundIndex != 0)
        {
            Play("Theme");
            audioMixer.SetFloat("volume", -80);

        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();

    }
}
