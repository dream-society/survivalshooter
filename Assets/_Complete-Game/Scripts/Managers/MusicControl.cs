using UnityEngine; using System; using System.Collections; using System.Collections.Generic;


public class MusicControl : MonoBehaviour
{      [FMODUnity.EventRef]     public string music = "event:/Music/Survival_Shooter";      FMOD.Studio.EventInstance musicEv;
    //FMOD.Studio.EventInstance instance = RuntimeManager.CreateInstance(fmodEvent);

    void Awake()
    {
        // Questo è per far sì che la musica continui quando il giocatore muore e rinasce,
        // e per evitare che la musica parta una seconda volta quando la scena viene ricaricata

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()     {         musicEv = FMODUnity.RuntimeManager.CreateInstance(music);         musicEv.start();         //musicEv.release();     }

    // Player has clicked "Play Now"
    public void GameStartedMusic()     {         musicEv.setParameterValue("GameStarted", 1f);     }

    // Called when the scene is loaded, it resets FMOD parameters. Useful when the scene reloads after
    // you die to allow you to play another game.
    public void ParametersReset()
    {
        musicEv.setParameterValue("PlayerHealth", 100f);
        musicEv.setParameterValue("IsUnderHalfHealth", 0f);
        musicEv.setParameterValue("IsDead", 0f);
    }

    // Player's health, updated when hit
    public void SetHealth(float health)
    {
        musicEv.setParameterValue("PlayerHealth", health);
    }

    // Player is less than 50% health
    public void IsUnderHalfHealthMusic()     {         musicEv.setParameterValue("IsUnderHalfHealth", 1f);     }

    // Player <=0 AKA: Game OVER
    public void IsDeadMusic()     {         musicEv.setParameterValue("IsDead", 1f);     }      public void AudioPause()
    {
        musicEv.setParameterValue("Pause", 1f);
    }

    public void AudioResume()
    {
        musicEv.setParameterValue("Pause", 0f);
    }      public void MXVolume(float volume)
    {
        musicEv.setParameterValue("MX_Volume", volume);
    } }

 