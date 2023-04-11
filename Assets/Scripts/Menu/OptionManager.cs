using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuManager;
    [SerializeField] private Slider Master, Music, SFX;
    [SerializeField] private AudioMixer mixer;

    public void CloseOptions()
    {
        gameObject.SetActive(false);
        MenuManager.SetActive(true);
    }

    public void OnEnable()
    {
        float val;
        mixer.GetFloat("MasterVolume", out val);
        Master.value = val;
        mixer.GetFloat("MusicVolume", out val);
        Music.value = val;
        mixer.GetFloat("SFXVolume",out val);
        SFX.value = val;
    }

    public void ChangeMasterVolume()
    {
       mixer.SetFloat("MasterVolume", Master.value);
    }

    public void ChangeMusicVolume()
    {
        mixer.SetFloat("MusicVolume", Music.value);
    }

    public void ChangeSfxVolume()
    {
        mixer.SetFloat("SFXVolume", SFX.value);
    }
}
