using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("saveVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
            SetMusic();
        }

    }

    public void SetVolume()
    {
        var volume = soundSlider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("saveVolume", volume);
    }

    public void SetMusic()
    {
        var music = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(music) * 20);
        PlayerPrefs.SetFloat("saveMusic", music);
    }

    private void LoadVolume()
    {
        soundSlider.value = PlayerPrefs.GetFloat("saveVolume");
        musicSlider.value = PlayerPrefs.GetFloat("saveMusic");

        SetVolume();
        SetMusic();
    }
}
