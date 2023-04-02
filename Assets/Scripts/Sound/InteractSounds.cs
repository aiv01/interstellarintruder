using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource myAudioSource;
    [SerializeField] private AudioClip idleClip, interactClip, idleBeforeClip;
    // Start is called before the first frame update
    void Start()
    {
        if(myAudioSource == null) myAudioSource = GetComponent<AudioSource>();
    }

   public void InteractSound()
   {
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.clip = interactClip;
            myAudioSource.Play();
        }
   }
   public void IdleSound()
   {
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.clip = idleClip;
            myAudioSource.Play();
        }
    }
    public void IdleBefore()
    {
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.clip = idleBeforeClip;
            myAudioSource.Play();
        }
    }
}
