using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStory : MonoBehaviour
{
	Text storyText;
	bool isComplete;
    public GameObject background;
    public GameObject playButton;
    string text1 = "Kamu diculik Pemangsa Gila!";
    string text2 = "Selesaikan semua misteri untuk kabur!";
    string text3 = "Selamat berjuang! ";
    string text4 = "HAHAHAHAHAHAHAHA";

    void Awake()
    {
    	storyText = this.gameObject.GetComponent<Text>();
    }

    void Start() 
    {
    	isComplete = false;
    }

    void Update()
    {
    	if (PlayerPrefs.GetInt("Story_2") == 1 && !isComplete) {
    		background.SetActive(true);
	    	isComplete = true;
	    	StartCoroutine(EffectTypewritter());
    	}
    }

    private IEnumerator EffectTypewritter() {
    	storyText.text = "";
    	yield return new WaitForSeconds(1.25f);
    	foreach(char character in text1.ToCharArray()) {
        	storyText.text += character;
    		yield return new WaitForSeconds(0.1f);
    	}
    	yield return new WaitForSeconds(1f);
    	storyText.text = "";
    	foreach(char character in text2.ToCharArray()) {
        	storyText.text += character;
    		yield return new WaitForSeconds(0.1f);
    	}
    	yield return new WaitForSeconds(2f);
    	storyText.text = "";
    	foreach(char character in text3.ToCharArray()) {
        	storyText.text += character;
    		yield return new WaitForSeconds(0.1f);
    	}
    	// yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("Story_3", 1);
        foreach(char character in text4.ToCharArray()) {
            storyText.text += character;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
    	PlayerPrefs.SetInt("Story_4", 1);

    	playButton.SetActive(true);
    }
}
