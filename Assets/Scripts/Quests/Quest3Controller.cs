using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest3Controller : MonoBehaviour
{
	public TMP_InputField input;
    public Camera[] playerCamera;

    public void CheckSolution()
	{
    	if (input.text == "1") {
    		this.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Quest3", 1);
            if (PlayerPrefs.GetString("CharacterUsed") == "Male")
            {
                playerCamera[0].orthographicSize = 0.7f;
                PlayerPrefs.SetFloat("Camera", 0.7f);
            }
            else if(PlayerPrefs.GetString("CharacterUsed") == "Female")
            {
                playerCamera[1].orthographicSize = 0.7f;
                PlayerPrefs.SetFloat("Camera", 0.7f);
            }
            Debug.Log("CORRECT");
    	} else {
    		Debug.Log("INCORRECT");
    	}
	}
}
