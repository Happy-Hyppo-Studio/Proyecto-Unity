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
    [SerializeField] private Slider mainSlider;

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
            SetMain();
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

    public void SetMain()
    {
        var main = mainSlider.value;
        audioMixer.SetFloat("main", Mathf.Log10(main) * 20);
        PlayerPrefs.SetFloat("saveMain", main);
    }

    private void LoadVolume()
    {
        soundSlider.value = PlayerPrefs.GetFloat("saveVolume");
        musicSlider.value = PlayerPrefs.GetFloat("saveMusic");
        mainSlider.value = PlayerPrefs.GetFloat("saveMain");

        SetVolume();
        SetMusic();
    }
}
