using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXController : MonoBehaviour
{
	public AudioSource Audio;

	public AudioClip Click;

    public static AudioSFXController SFXInstance;

    void Awake() {
        if (SFXInstance != null && SFXInstance != this) {
            Destroy(this.gameObject);
            return;
        }

        SFXInstance = this;
    }

    public void SoundClick() {
        AudioSFXController.SFXInstance.Audio.PlayOneShot(AudioSFXController.SFXInstance.Click);
    }
}
