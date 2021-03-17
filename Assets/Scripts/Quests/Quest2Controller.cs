using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest2Controller : MonoBehaviour
{
	public TMP_InputField input;
    public Camera[] playerCamera;

    public void CheckSolution()
	{
    	if (input.text == "9") {
    		this.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Quest2", 1);
            if (PlayerPrefs.GetString("CharacterUsed") == "Male")
            {
                if (PlayerPrefs.GetInt("Quest3") != 1)
                {
                    playerCamera[0].orthographicSize = 0.6f;
                    PlayerPrefs.SetFloat("Camera", 0.6f);
                }
                 
            }
            else if (PlayerPrefs.GetString("CharacterUsed") == "Female")
            {
                if (PlayerPrefs.GetInt("Quest3") != 1)
                {
                    playerCamera[1].orthographicSize = 0.6f;
                    PlayerPrefs.SetFloat("Camera", 0.6f);
                }
            }
            Debug.Log("CORRECT");
    	} else {
    		Debug.Log("INCORRECT");
    	}
	}
}
