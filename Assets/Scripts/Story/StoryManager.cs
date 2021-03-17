using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public GameObject MaleCharacter, FemaleCharacter;

    public AudioSource audioSourceMusic, audioSourceSFX;
    public AudioClip music_1, music_2, music_screaming, music_laughing;

    bool isSound2Played;
    bool isSoundScreamPlayed;
    bool isSoundLaughPlayed;

    void Awake() {
        isSound2Played = false;
        isSoundScreamPlayed = false;
        isSoundLaughPlayed = false;
    	audioSourceMusic.clip = music_1;
        audioSourceMusic.volume = PlayerPrefs.GetFloat("Music");
    	audioSourceSFX.volume = PlayerPrefs.GetFloat("Music") * 3f;

        PlayerPrefs.SetInt("Story_1", 0);
        PlayerPrefs.SetInt("Story_2", 0);
        PlayerPrefs.SetInt("Story_3", 0);
        PlayerPrefs.SetInt("Story_4", 0);

        if (PlayerPrefs.GetString("CharacterUsed") == "Male") {
   			MaleCharacter.SetActive(true);
   			FemaleCharacter.SetActive(false);
    	} else if (PlayerPrefs.GetString("CharacterUsed") == "Female") {
   			FemaleCharacter.SetActive(true);
    		MaleCharacter.SetActive(false);
		} else {
			SceneManager.LoadScene("ChooseCharacterScene");
		}
    }

    void Start()
    {
    	audioSourceMusic.Play();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Story_1") == 1 && !isSoundScreamPlayed) {
            audioSourceSFX.clip = music_screaming;
            isSoundScreamPlayed = true;
            audioSourceSFX.Play();
        }
    	if (PlayerPrefs.GetInt("Story_2") == 1 && !isSound2Played) {
            isSound2Played = true;
    		audioSourceMusic.clip = music_2;
    		audioSourceMusic.Play();
    	}
        if (PlayerPrefs.GetInt("Story_3") == 1 && !isSoundLaughPlayed) {
            audioSourceSFX.clip = music_laughing;
            isSoundLaughPlayed = true;
            audioSourceSFX.Play();
        }
    }
}
