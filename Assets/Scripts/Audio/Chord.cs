using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Chord : MonoBehaviour
{
    public EventReference chord;

    public void PlayChord()
    {
        AudioManager.instance.PlayOneShot(chord, this.transform.position);
    }
}
