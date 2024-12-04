using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider MasterVolumeslider;
    [SerializeField] private Slider MusicVolumeslider;
    [SerializeField] private Slider SoundFXVolumeslider;

    private void Start()
    {
        // ���� ����� ������ �� ���� ����� ���� �� �� �����
        MasterVolumeslider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        MusicVolumeslider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        SoundFXVolumeslider.value = PlayerPrefs.GetFloat("SoundFXVolume", 0.75f);

        // ����� �� ������ �� �-AudioMixer
        SetMasterVolume(MasterVolumeslider.value);
        SetMusicVolume(MusicVolumeslider.value);
        SetSoundFXVolume(SoundFXVolumeslider.value);
    }

    // ������� ������ ������� ����� �-Master
    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Max(level, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("MasterVolume", level); // ����� ����
        PlayerPrefs.Save(); // ����� �����
    }

    // ������� ������ ������� ����� �������
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Max(level, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("MusicVolume", level);
        PlayerPrefs.Save();
    }

    // ������� ������ ������� ����� ������
    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(Mathf.Max(level, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("SoundFXVolume", level);
        PlayerPrefs.Save();
    }
}
