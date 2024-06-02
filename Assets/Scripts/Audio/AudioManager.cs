using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private EventInstance ambianceEventInstance;
    private EventInstance musicEventInstance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already an instance of AudioManager in the scene");
        }
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(sound, worldPosition);
    }

    private void Start()
    {
        InitializeAmbiance(FMODEvents.instance.ambianceLv1);
        InitializeMusic(FMODEvents.instance.music);
    }
    private void InitializeAmbiance(EventReference ambianceEventReference)
    {
        ambianceEventInstance = RuntimeManager.CreateInstance(ambianceEventReference);
        ambianceEventInstance.start();
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = RuntimeManager.CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    public void SetMusicState(MusicState state)
    {
        musicEventInstance.setParameterByName("state", (float)state);
    }

}
