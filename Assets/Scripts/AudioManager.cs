using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip music, SFX;
    public AudioSource audioSourceMusic, audioSourceSFX;
    public Slider sliderMusic, sliderSFX;

    void Start() {
        if (PlayerPrefs.HasKey("Music") == false) {
            PlayerPrefs.SetFloat("Music", 0.6f);
        }
        if (PlayerPrefs.HasKey("SFX") == false) {
            PlayerPrefs.SetFloat("SFX", 0.6f);
        }

    	audioSourceMusic.clip = music;
    	audioSourceMusic.Play();
    	audioSourceSFX.clip = SFX;

        if (sliderMusic) {
            sliderMusic.value = PlayerPrefs.GetFloat("Music");
        }
        if (sliderSFX) {
            sliderSFX.value = PlayerPrefs.GetFloat("SFX");
        }
    }

    void Update() {
        audioSourceMusic.volume = PlayerPrefs.GetFloat("Music");
        audioSourceSFX.volume = PlayerPrefs.GetFloat("SFX");
    }

    public void SetMusic() {
        PlayerPrefs.SetFloat("Music", sliderMusic.value);
    }

    public void SetSFX() {
        PlayerPrefs.SetFloat("SFX", sliderSFX.value);
    }
}
